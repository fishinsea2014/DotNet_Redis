using Jason.Redis.Libs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jason.Redis
{
    public class ServiceStackTest
    {
        public static void Show()
        {
            Student student_1 = new Student()
            {
                Id = 11,
                Name = "Eleven"
            };
            Student student_2 = new Student()
            {
                Id = 12,
                Name = "Twelve",
                Remark = "123423245"
            };

            Console.WriteLine("====Basic redis test====");
            {
                using (RedisStringService service = new RedisStringService())
                {
                    service.Set<string>("student1", "May");
                    Console.WriteLine(service.Get("student1"));

                    service.Append("student1", " from china");
                    Console.WriteLine($"After append : {service.Get("student1")}");

                    service.GetAndSetValue("student1", "Modified May ");
                    Console.WriteLine(service.Get("student1"));

                    service.Set<string>("stu2", "Lee", DateTime.Now.AddSeconds(5));
                    //Thread.Sleep(1000);
                    Console.WriteLine(service.Get("stu2"));

                    service.Set<int>("age", 23);
                    service.Incr("age");
                    Console.WriteLine($"After Incr: {service.Get("age")}");
                    service.IncrBy("age",10);
                    Console.WriteLine($"After Incr by 10: {service.Get("age")}");
                    service.Decr("age");
                    Console.WriteLine($"After Decr: {service.Get("age")}");
                    service.DecrBy("age",10);
                    Console.WriteLine($"After Decr by 10: {service.Get("age")}");
                }

                {
                    Console.WriteLine("===Basic redis hash table===");
                    using(RedisHashService service = new RedisHashService())
                    {
                        service.SetEntryInHash("stuHash", "id", "123");
                        service.SetEntryInHash("stuHash", "name", "MayHash");
                        service.SetEntryInHash("stuHash", "remark", "Graudate");

                        var keys = service.GetHashKeys("stuHash");
                        var values = service.GetHashValues("stuHash");
                        var keyValues = service.GetAllEntriesFromHash("stuHash");

                        string valueId = service.GetValueFromHash("stuHash","id");
                        Console.WriteLine(valueId);

                        service.SetEntryInHashIfNotExists("stuHash", "name", "MayHashUpdated");
                        service.SetEntryInHashIfNotExists("stuHash", "description", "Advanced class");
                        Console.WriteLine(service.GetValueFromHash("stuHash", "name"));
                        Console.WriteLine(service.GetValueFromHash("stuHash", "description"));
                        service.RemoveEntryFromHash("stuHash", "description");
                        Console.WriteLine($"After remove: {service.GetValueFromHash("stuHash", "description")}");
                    }
                }
            }
        }
    }
}
