using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProject.HW1
{
    //Programin ozellikleri:
    //Parantezli ifadeler ile islem onceligi verilerek hesaplamalar yapabilir
    //Sadece temel 4 islemi yapabilir
    //Girilen islemin kurallara uygun arada bosluk bırakılmadigini kabul eder
    //18/6*2 gibi benzer islemlerde oncelik parantezler ile belirtilmezse default carpma islemi tanimlanmistir
    class Test
    {
        public static void Main(string[] args)
        {
            Console.Write("Please input infix: ");
            string str = Console.ReadLine();

            Postfix post = new Postfix(str);

            Console.Write("\nOrder infix out: ");
            post.display();
            
            Console.Write("\nPostfix out: ");
            post.convertToPostfix();
            post.display();

            Console.Write("\nResult: ");
            post.cal();
            post.display();

            
            
        }
    }
}
