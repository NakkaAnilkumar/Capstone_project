using System.Collections.Generic;
using System;
using System.Data.Entity;

namespace DAL
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<AdminInfo> adminInfos = new List<AdminInfo>();

            adminInfos.Add(new AdminInfo() { Email = "sunny1999@gmail.com", Password = "sunny@123" });
            adminInfos.Add(new AdminInfo() { Email = "bunny1998@gmail.com", Password = "bunny@123" });

            context.AdminInfos.AddRange(adminInfos);
            context.SaveChanges();

            List<EmpInfo> empInfos = new List<EmpInfo>();
            empInfos.Add(new EmpInfo() { Email = "ramesh@gmail.com", PassCode = 123, DateOfJoining = new DateTime(2020, 10, 05), Name = "ramesh" });
            empInfos.Add(new EmpInfo() { Email = "suresh@gmail.com", PassCode = 234, DateOfJoining = new DateTime(2019, 10, 25), Name = "suresh" });
            empInfos.Add(new EmpInfo() { Email = "naresh@gmail.com", PassCode = 345, DateOfJoining = new DateTime(2020, 11, 05), Name = "naresh" });
            context.EmpInfos.AddRange(empInfos);
            context.SaveChanges();

            List<BlogInfo> blogInfos = new List<BlogInfo>();
            blogInfos.Add(new BlogInfo() { Email = "ramesh@gmail.com", BlogUrl = "https://www.flipkart.com/", DateOfCreation = new DateTime(2020, 10, 10), Subject = "shopping", Title = "Anil's Desk" });
            blogInfos.Add(new BlogInfo() { Email = "suresh@gmail.com", BlogUrl = "https://www.amazon.in/", DateOfCreation = new DateTime(2020, 10, 26), Subject = "shopping", Title = "Anil's Desk" });
            blogInfos.Add(new BlogInfo() { Email = "naresh@gmail.com", BlogUrl = "https://www.google.co.in/", DateOfCreation = new DateTime(2020, 11, 06), Subject = "Search Engine", Title = "Anil's Desk" });
            context.BlogInfos.AddRange(blogInfos);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}