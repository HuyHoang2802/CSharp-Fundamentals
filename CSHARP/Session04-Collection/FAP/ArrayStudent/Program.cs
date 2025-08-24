using ArrayStudent.Entities;

namespace ArrayStudent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayWithStudentArrayV5();
        }
        static void PlayWithStudentArrayV5()
        {
            Student s1 = new Student() { Id = "SE2", Name = "Binh" };
            //Lưu hồ sơ của 30 sv 
            Student[] arr = new Student[30];
            arr[0] = s1;
            arr[1] = new Student() { Id = "SE3", Name = "Cuong" };
            arr[2] = new Student() { Id = "SE4", Name = "Dung" };
            arr[3] = new Student() { Id = "SE5", Name = "Giang" };

            //Em thích for hết dù mảng chưa full, chứa null từa lưa cuối mảng, 26 biến Student 
            //đang null 
            //For hết là Exception 
            Console.WriteLine("The student list printed by using for i");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] is not  null)
                arr[i].ShowProfle(); //tầng chấm 2 
            }



        }


        static void PlayWithStudentArrayV3()
        {
            Student s1 = new Student() { Id = "SE2", Name = "Binh" };
            //Lưu hồ sơ của 30 sv 
            Student[] arr = new Student[30];
            arr[0] = s1;
            arr[1] = new Student() {Id ="SE3", Name = "Cuong" };
            arr[2] = new Student() {Id = "SE4", Name = "Dung" };
            arr[3] = new Student() { Id = "SE5", Name = "Giang" };

            Console.WriteLine("The student list printed by using for i");
            for (int i = 0; i < 4; i++)           
                arr[i].ShowProfle();
            
            foreach (Student x in arr)
            {
                x.ShowProfle();
                //chạy từ đầu mảng đến cuối mảng 
                //[4] = null 

            }
           

        }
        static void PlayWithStudentArray2()
        {
            Student s1 = new Student();
            s1.Id = "SE1";
            s1.Name = "An"; //đang gọi hàm SET()

            Student s2 = new Student() { Id = "SE2", Name = "Binh" };

            Student[] arr = new Student[] 
            {
                new Student() { Id = "SE3" }, //[0]
                new Student() { Id = "SE4" }  //[1]
            };
            Console.WriteLine("The student list");
            arr[0].ShowProfle();
            arr[1].ShowProfle();

        }
        static void PlayWithStudentArray()
        {
            //Một hồ sơ sinh viên 
            Student s1 = new Student();
            s1.Id = "SE1";
            s1.Name = "An"; //đang gọi hàm SET()

            Student s2 = new Student() { Id = "SE2", Name = "Binh" };

            Student[] arr = new Student[] { s1, s2 };
            //arr[0] trỏ cùng = s1 = trỏ cùng SE1 An ở trên 
            Console.WriteLine("1. Check [0] pointing to SE1 | An");
            arr[0].ShowProfle();
            arr[0].Gpa = 8.6;
            Console.WriteLine("2. Check s1 poiting to SE1 | An | 8.6");
            s1.ShowProfle();

        }
    }
}
