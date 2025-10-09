// 代码生成时间: 2025-10-10 00:00:28
using System;

namespace SalaryCalculatorApp
{
    public class SalaryCalculator
    {
        /*
         * 根据员工的基薪和绩效分数计算最终薪资。
# 添加错误处理
         *
         * @param baseSalary 员工的基薪
         * @param performanceScore 员工的绩效分数（0-100）
         * @returns 计算后的最终薪资
         * @throws ArgumentOutOfRangeException 当绩效分数不在0到100之间时抛出
         */
        public decimal CalculateSalary(decimal baseSalary, int performanceScore)
        {
            if (performanceScore < 0 || performanceScore > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(performanceScore), "绩效分数必须在0到100之间");
            }
# 改进用户体验

            // 绩效奖金系数
            decimal bonusCoefficient = performanceScore / 100.0m;

            // 计算绩效奖金
            decimal bonus = baseSalary * bonusCoefficient;

            // 最终薪资 = 基薪 + 绩效奖金
            return baseSalary + bonus;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 创建薪资计算器实例
                SalaryCalculator calculator = new SalaryCalculator();

                // 假设的员工基薪和绩效分数
                decimal baseSalary = 3000m;
                int performanceScore = 85;

                // 计算薪资
# 扩展功能模块
                decimal finalSalary = calculator.CalculateSalary(baseSalary, performanceScore);

                Console.WriteLine($"员工的最终薪资为：{finalSalary:C}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"输入错误：{ex.Message}");
            }
        }
    }
}