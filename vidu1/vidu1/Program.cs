using System;
using System.Text;

class Program
{
    static void Main()
    {
        //sức chứa của balo và số lượng món đồ
        int M = 4; //sức chứa balo
        int N = 2;  //số lượng món đồ

        //kích thước và giá trị của các món đồ (phần tử chỉ số 0 không sử dụng)
        int[] size = { 0, 2, 3 }; //kích thước của các món đồ
        int[] val = { 0, 3, 4 };  //giá trị của các món đồ

        //khởi tạo cost và best
        int[] cost = new int[M + 1];
        int[] best = new int[M + 1];

        for (int i = 0; i <= M; i++)
        {
            cost[i] = 0;
            best[i] = 0;
        }

        //ap dụng phương pháp lập trình động để giải bài toán balo
        for (int j = 1; j <= N; j++) // Lặp qua từng loại món đồ
        {
            for (int i = M; i >= size[j]; i--) // Sức chứa từ M đến kích thước của món đồ hiện tại
            {
                if (cost[i] < cost[i - size[j]] + val[j])
                {
                    cost[i] = cost[i - size[j]] + val[j];
                    best[i] = j;
                }
            }
        }
        Console.OutputEncoding = Encoding.UTF8;
        //in ra giá trị tối đa và các món đồ được chọn
        Console.WriteLine("Giá trị tối đa trong balo với sức chứa " + M + " là: " + cost[M]);
        Console.WriteLine("Các món đồ đã được chọn trong balo:");
        int remainingCapacity = M;
        while (remainingCapacity > 0 && best[remainingCapacity] != 0)
        {
            int item = best[remainingCapacity];
            Console.WriteLine("Món đồ " + item + " với kích thước " + size[item] + " và giá trị " + val[item]);
            remainingCapacity -= size[item];
            Console.ReadLine();
        }
    }
}
