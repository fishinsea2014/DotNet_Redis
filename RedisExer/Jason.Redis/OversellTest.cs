using Jason.Redis.Libs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jason.Redis
{
    /// <summary>
    /// Privide there are 10 items in stock. Seller want to do a seckilling 
    /// Provide 100 client anticipate the seckilling at same time
    /// </summary>
    public class OversellTest
    {
        private static bool IsGoOn = true; //Continuing seckilling

        public static void Show()
        {
            using(RedisStringService service= new RedisStringService())
            {
                service.Set<int>("Stock", 10); //Set 10 items in store
            }

            for (int i =0; i<100; i++) //Provide 100 client take part in the second kill
            {
                int k = i;
                Task.Run(() =>
                {
                    using (RedisStringService service = new RedisStringService())
                    {
                        if (IsGoOn)
                        {
                            long index = service.Decr("Stock");
                            if (index >= 0)
                            {
                                Console.WriteLine($"{k.ToString("000")} seckilling succeed, index of item is {index}");

                            }
                            else
                            {
                                if (IsGoOn)
                                {
                                    IsGoOn = false;
                                    Console.WriteLine($"{k.ToString("000")} seckilling failed, index of item is {index}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{k.ToString("000")} , seckilling is over, sorry.");
                        }
                    }
                }
                    );

            }
        }
    }
}
