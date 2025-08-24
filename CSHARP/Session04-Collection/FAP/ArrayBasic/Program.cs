namespace ArrayBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PLayWithIntegerListV6();
        }
        //Challenge 1: Hãy lưu trữ và in ra 5 10 15 20 ........
        //Lưu trữ nhiều DATA, chưa bàn xử lí 

        //Lưu dữ liệu trong RAM: biến
        //Lưu trữ dữ liệu lâu dài: trên các thiết bị lưu trữ HDD/SSD
        //Cây thư mục , database 
        //Cần nhiều biến thì lưu được nhiều value 
        //Vì tại 1 thời điểm, 1 biến lưu 1 value 

        static void PLayWithIntegerListV6()
        {
            int a = 10;
            int b = a;
            int[] arr1 = { 5, 10, 15, 20, 25 }; // new ngầm int[4] xin 4 biến int 

            int[] arr2 = { 2, 4, 6, 8, 1, 3, 5, 7 };

            Console.WriteLine("arr2 at first");
            foreach (int i in arr2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            arr2 = arr1; //2 chàng 1 nàng 
            arr1[0] = 999;
            Console.WriteLine("arr2 at second: ");
            foreach (int i in arr2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            arr2[1] = 662024;
            Console.WriteLine();
            Console.WriteLine("arr2 at third : ");
            foreach (int i in arr1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }


        static void PLayWithIntegerListV5()
        {
            int[] arr = new int[10]; //10 element/10 phần tử 
            arr[0] = 5;
            arr[1] = 10;
            arr[2] = 15;
            arr[3] = 20;
            //Gán trước 4 giá trị cho 4 biến đuầ, hỏi rằng 6 biến còn lại là mấy 
            //Vùng 6 biến int còn lại sẽ mang default - object là vậy ko điền đủ in4 là mang default 
            Console.WriteLine("the list of number: ");
            for (int i = 0; i < arr.Length; i++)          
                Console.Write(arr[i] + " ");       
            
            foreach (int i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }




        //TOÁN TỬ VỚI MỌI TRONG TẬP HỢP 
        static void PLayWithIntegerListV4()
        {
            int[] arr = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };

            Console.WriteLine("The list of 5 ...10: ");
            foreach (int x in arr) //Với x ròi vào in tập arr, thì x có thể arr[0], x = arr[1],  x= arr[i] - toán tử với mọi trong toán 
                                    // chơi với x chính là chơi với arr[i]
            {
                Console.Write($"{x} "); //chính là chơi từng arr[i] 
                                            //Với mọi x sẽ quét qua hết từng phần tử trong mảng, để lấy value 
            }
            Console.WriteLine();
            //FORE tab tab để gợi ý cú pháp in mảng dùng toán tử với mọi 

            foreach (var x in arr) //Với x ròi vào in tập arr, thì x có thể arr[0], x = arr[1],  x= arr[i] - toán tử với mọi trong toán 
                                   // chơi với x chính là chơi với arr[i]
            {
                Console.Write($"{x} "); //chính là chơi từng arr[i] 
                                        //Với mọi x sẽ quét qua hết từng phần tử trong mảng, để lấy value 
            }
            Console.WriteLine();
        }
        static void PLayWithIntegerListV3() 
        {
            int[] arr = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
            //in mảng 
            Console.WriteLine("The list of 5 -> 50 ");
            Console.WriteLine($"{arr[0]} {arr[1]} {arr[2]} {arr[3]} {arr[4]} {arr[5]} {arr[6]} {arr[7]} {arr[8]} {arr[9]}");
            //Xài lố phần tử, app bị giết ngay - out of range exception 
            Console.WriteLine("The list of 5 ...10 using for i");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            //tính tổng 
            int sum = 0;
            Console.WriteLine("The sum list of 5 ...10 using for i");
            //for (int i = 0; i < 10; i++)
                for (int i = 0; i < arr.Length; i++)
                {
                sum += arr[i];               
            }
            Console.WriteLine("Sum: " + sum);
        }

        static void PLayWithIntegerListV1()
        {
            //Mảng là kĩ thuật khâi báo biến, Nhiều biến 1 cách hiệu quả 
            //mảng là kĩ thuật khai baoas nhiều biến cùng luc , cùng kiểu, cùng tên và ở sát nhau trong RAM Y chang nhà liền kề 
            int[] arr;
            int[] arr2 = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
            int[] arr3 = [5, 10, 15, 20, 25, 30, 35, 40, 45, 50];
            int[] arr4 =  new int [10] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
            int[] arr5 = new int[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
            int[] arr6;
            arr6 = new int[10];
            arr6[0] = 5;
            arr6[1] = 10;
            arr6[2] = 15;
            arr6[3] = 20;
            arr6[4] = 25;

            int[] arr8 = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
            int[] arr9 = new int[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };

        }
        static void PLayWithIntegerListV2()
        {

            for (int i = 1; i <= 50; i++)
            {
                if (i % 5 == 0)
                    Console.Write($"{i} ");
            }
        }
    }
}
