using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProject.HW1
{
    class Calculate
    {   
        //Her isaretten sonraki iki degeri aldigi isarete gore degerini donderir.
        protected void calculatePostfix(Stack<string> stck)
        {
            Stack<string> tempstck = new Stack<string>(stck.size());
            
            while (!stck.isEmpty())
            {
                string temp = stck.pop();
                string a = null;
                string b = null;

                if (temp == "+")
                {
                    tempstck.push(addition(tempstck.pop(), tempstck.pop()));
                }
                else if (temp == "-")
                {
                    a = tempstck.pop(); //Cikan deger
                    b = tempstck.pop(); //Eksilen deger
                    tempstck.push(subraction(b, a));
                }

                else if (temp == "*")
                {
                    tempstck.push(multiplicaiton(tempstck.pop(), tempstck.pop()));
                }

                else if (temp == "/")
                {
                    a = tempstck.pop(); //bolen deger
                    b = tempstck.pop(); //Bolunen deger
                    tempstck.push(division(b, a)); 
                }

                else
                {
                    tempstck.push(temp);
                }
            }

            while (!tempstck.isEmpty())
            {
                stck.push(tempstck.pop());
            }
        }

        //Toplama islemi 
        private string addition (string a, string b)
        {
            return Convert.ToString(Convert.ToDouble(a) + Convert.ToDouble(b));
        }

        //Cikarma islemi    
        private string subraction(string a, string b)
        {
            return Convert.ToString(Convert.ToDouble(a) - Convert.ToDouble(b));
        }

        //Carpma islemi
        private string multiplicaiton(string a, string b)
        {
            return Convert.ToString(Convert.ToDouble(a) * Convert.ToDouble(b));
        }

        //Bolme islemi
        private string division(string a, string b)
        {
            return Convert.ToString(Convert.ToDouble(a) / Convert.ToDouble(b));
        }
    }
}
