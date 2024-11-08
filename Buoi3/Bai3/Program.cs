using System;
using System.Collections.Generic;

namespace Bai3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> Manage = new Dictionary<string, Dictionary<string, int>>();

            // Thêm dữ liệu bán hàng để kiểm tra các phương thức
            Add(Manage);
            Add(Manage);

            FindTopEmployee(Manage);
            FindTopProduct(Manage);
        }

        // Thêm dữ liệu bán hàng mới
        static void Add(Dictionary<string, Dictionary<string, int>> Manage)
        {
            Console.Write("Nhập tên nhân viên: ");
            string employeeName = Console.ReadLine();

            Console.Write("Nhập tên sản phẩm: ");
            string productName = Console.ReadLine();

            Console.Write("Nhập số lượng: ");
            int quantity = int.Parse(Console.ReadLine());

            if (!Manage.ContainsKey(employeeName))
            {
                Manage[employeeName] = new Dictionary<string, int>();
            }

            if (Manage[employeeName].ContainsKey(productName))
            {
                Manage[employeeName][productName] += quantity;
            }
            else
            {
                Manage[employeeName][productName] = quantity;
            }
        }

        // Tìm nhân viên bán được tổng số lượng sản phẩm nhiều nhất
        static void FindTopEmployee(Dictionary<string, Dictionary<string, int>> Manage)
        {
            string topEmployee = null;
            int maxTotalQuantity = 0;

            foreach (var employee in Manage)
            {
                int employeeTotal = 0;
                foreach (var product in employee.Value)
                {
                    employeeTotal += product.Value;
                }

                if (employeeTotal > maxTotalQuantity)
                {
                    maxTotalQuantity = employeeTotal;
                    topEmployee = employee.Key;
                }
            }

            if (topEmployee != null)
            {
                Console.WriteLine($"Nhân viên bán được nhiều sản phẩm nhất là: {topEmployee} với tổng số lượng {maxTotalQuantity}");
            }
            else
            {
                Console.WriteLine("Không có dữ liệu trong danh sách.");
            }
        }

        // Tìm sản phẩm bán chạy nhất dựa trên tổng số lượng từ tất cả các nhân viên
        static void FindTopProduct(Dictionary<string, Dictionary<string, int>> Manage)
        {
            Dictionary<string, int> productTotals = new Dictionary<string, int>();

            foreach (var employee in Manage)
            {
                foreach (var product in employee.Value)
                {
                    if (productTotals.ContainsKey(product.Key))
                    {
                        productTotals[product.Key] += product.Value;
                    }
                    else
                    {
                        productTotals[product.Key] = product.Value;
                    }
                }
            }

            string topProduct = null;
            int maxProductQuantity = 0;

            foreach (var product in productTotals)
            {
                if (product.Value > maxProductQuantity)
                {
                    maxProductQuantity = product.Value;
                    topProduct = product.Key;
                }
            }

            if (topProduct != null)
            {
                Console.WriteLine($"Sản phẩm bán chạy nhất là: {topProduct} với tổng số lượng {maxProductQuantity}");
            }
            else
            {
                Console.WriteLine("Không có dữ liệu trong danh sách.");
            }
        }
    }
}
