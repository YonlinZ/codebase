using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardQueryOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new Dictionary<string, int>
            {
                { "A",1 },{"B", 2},{"C",3},{"D",3 }, {"E",4 }, {"F", 4}, {"G",4 }
            };

            var salarys = new Dictionary<int, string>
            {
                { 1, "6k~9k"},{2, "9k~12k"},{3,"12k~16"}, {4, "16k+"}
            };

            #region 以访问集合接口方式遍历集合

            //var iterator = employees.GetEnumerator();
            //using (iterator)
            //{
            //    while (iterator.MoveNext())
            //    {
            //        Console.WriteLine(iterator.Current);
            //    }
            //}

            #endregion

            #region 测试Where筛选，Select映射，BrderByDescending排序

            //Console.WriteLine("测试Where筛选，Select映射，BrderByDescending排序".PadLeft(50, '↓').PadRight(100, '↓'));
            //foreach (var i in employees
            //    .Where(item => item.Value > 2)
            //    .Select(item => item.Key.PadRight(10, '-'))
            //    .OrderByDescending(item => item))
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine();
            #endregion

            #region 测试Join联接

            //Console.WriteLine("测试Join联接".PadLeft(50, '↓').PadRight(100, '↓'));
            //var emAndSalary = employees.Join(salarys, emp => emp.Value, salary => salary.Key, (emp, salary) => new
            //{
            //    name = emp.Key,
            //    level = emp.Value,
            //    salary = salary.Value
            //}
            //);

            //foreach (var x1 in emAndSalary)
            //{
            //    Console.WriteLine(x1);
            //}

            //Console.WriteLine();
            #endregion

            #region 测试GroupBy分组

            //Console.WriteLine("测试GroupBy分组".PadLeft(50, '↓').PadRight(100, '↓'));
            //var groupedList = employees.GroupBy(i => i.Value);

            //foreach (var groupItem in groupedList)
            //{
            //    Console.WriteLine($"Level {groupItem.Key}:");
            //    foreach (var keyValuePair in groupItem)
            //    {
            //        Console.WriteLine($"{keyValuePair.Key}----{keyValuePair.Value}");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine();
            #endregion

            #region 测试GroupJoin实现一对多关系

            //Console.WriteLine("测试GroupJoin实现一对多关系".PadLeft(50, '↓').PadRight(100, '↓'));

            //var itemGroupJoin = salarys.GroupJoin(employees, 
            //    salary => salary.Key, 
            //    emp => emp.Value, 
            //    (salary, emp) => new { salary.Key, salary.Value, emp });
            //foreach (var x in itemGroupJoin)
            //{
            //    Console.WriteLine($"Level: {x.Key}__Salary Range: {x.Value}");
            //    foreach (var kvp in x.emp)
            //    {
            //        Console.WriteLine($"Employees: {kvp.Key}__{kvp.Value}");
            //    }
            //}

            //Console.WriteLine("测试GroupJoin统计".PadLeft(50, '↓').PadRight(100, '↓'));

            //var itemCount = salarys.GroupJoin(employees,
            //    salary => salary.Key,
            //    emp => emp.Value,
            //    (salary, emp) => new { salary.Key, salary.Value, emp }).Select(x=>new {x.Key, x.Value, count = x.emp.Count()});
            //foreach (var item in itemCount)
            //{
            //    Console.WriteLine($"{item.Value}__{item.Key}__{item.count}");

            //}
            #endregion

            #region 测试SelectMany合并子集合
            //Console.WriteLine("测试SelectMany合并子集合".PadLeft(50, '↓').PadRight(100, '↓'));

            //string[] characters = {"A B C", "D E", "F J H" };

            //IEnumerable<string[]> splitChars1 = characters.Select(character => character.Split(' '));
            //Console.WriteLine("遍历两次");
            //foreach (var charArrar in splitChars1)
            //{
            //    foreach (var s in charArrar)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
            //Console.WriteLine("遍历一次");
            //IEnumerable<string> splitChars2 = characters.SelectMany(character => character.Split(' '));
            //foreach (var splitChar in splitChars2)
            //{
            //    Console.WriteLine(splitChar);
            //}


            //PetOwner[] petOwners =
            //{ new PetOwner { Name="Higa",
            //        Pets = new List<string>{ "Scruffy", "Sam" } },
            //    new PetOwner { Name="Ashkenazi",
            //        Pets = new List<string>{ "Walker", "Sugar" } },
            //    new PetOwner { Name="Price",
            //        Pets = new List<string>{ "Scratches", "Diesel" } },
            //    new PetOwner { Name="Hines",
            //        Pets = new List<string>{ "Dusty" } } };

            //// Project the pet owner's name and the pet's name.
            //// 方法解释：
            ////      petOwner => petOwner.Pets  返回一个集合IEnumerable<string>，保存各个宠物。
            ////      (petOwner, petName) => new {petOwner, petName}  petOwner指的是petOwners中的各个PetOwner实例，petName指的是上一个Func返回的集合IEnumerable<string>中的元素，这里是各个宠物
            //var query = petOwners
            //    .SelectMany(petOwner => petOwner.Pets, (petOwner, petName) => new {petOwner, petName})
            //        .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
            //        .Select(ownerAndPet =>
            //            new
            //            {
            //                Owner = ownerAndPet.petOwner.Name,
            //                Pet = ownerAndPet.petName
            //            }
            //        );

            //// Print the results.
            //foreach (var obj in query)
            //{
            //    Console.WriteLine(obj);
            //}
            #endregion

            int[] arr1 = {0,1,2,3,4,5 };
            int[] arr2 = { 1,3,5,5,7};

            var query = from val1 in arr1
                        join val2 in arr2 on val1 equals val2 into val2Grop
                        from grp in val2Grop.DefaultIfEmpty(100)
                        select new { VAL1 = val1, GRP = grp };

            var l = query.ToList();

            Console.ReadKey();
        }


    }

    class PetOwner
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }
    }
}
