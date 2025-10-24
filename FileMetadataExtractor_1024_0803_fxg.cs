// 代码生成时间: 2025-10-24 08:03:12
 * Usage:
 *   - Pass the file path as a parameter to the ExtractMetadata method.
 * 
 * Features:
 *   - Retrieves the file's creation time, last write time, and size.
 *   - Handles exceptions for file not found and unauthorized access.
 */

using System;
using System.IO;

public class FileMetadataExtractor
{
    /// <summary>
    /// Extracts metadata from a file specified by its path.
    /// </summary>
    /// <param name="filePath">The path to the file from which to extract metadata.</param>
    /// <returns>A string containing the file's metadata.</returns>
    public static string ExtractMetadata(string filePath)
    {
        try
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file was not found.", filePath);
            }

            // Get the FileInfo object for the specified file
            FileInfo file = new FileInfo(filePath);

            // Extract metadata
            string metadata = $"File Name: {file.Name}
" +
                             $"Creation Time: {file.CreationTime}
" +
                             $"Last Write Time: {file.LastWriteTime}
" +
                             $"Size: {file.Length} bytes";

            return metadata;
        }
        catch (UnauthorizedAccessException)
        {
            // Handle the case where the application does not have permission to access the file.
            return "Access to the file is denied.";
        }
        catch (Exception ex)
        {
            // Handle any other exceptions that may occur.
            return $"An error occurred: {ex.Message}";
        }
    }

    /// <summary>
    /// Main method for testing the FileMetadataExtractor.
    /// </summary>
    /// <param name="args">Command line arguments (file path).</param>
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a file path as an argument.");
            return;
        }

        string metadata = ExtractMetadata(args[0]);
        Console.WriteLine("File Metadata:
" + metadata);
    }
}