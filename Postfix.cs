using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProject.HW1
{
    /*Calculate sinifinin calculatePostfix metodunu
     kullanmak icin Calculate sinifindan kalitim aldim*/
    class Postfix:Calculate  
    {
        Stack<string> stck;
        Stack<string> posfixStck; //Degisgenler orderForPostfix() ve convertToPostfix()
        Stack<string> singStck;   //metodlarinda kullanilmistir.
        Boolean flag = false;
        int stackSize; 

        //Gelen string ifade stack de depolanacak sekilde ayrilir
        public Postfix(string str)
        {
            this.stackSize = stckSize(str);

            stck = new Stack<string>(stackSize);
            posfixStck = new Stack<string>(stackSize);
            singStck = new Stack<string>(singSize());

            string value = null;

            //Isaretler ve sayilar birbirinden ayrilir
            //stck ya push edilir
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '+' || str[i] == '-' || str[i] == '/' || str[i] == '*' || str[i] == '(' || str[i] == ')')
                {
                    if (value != null)
                    {
                        stck.push(value);
                        value = null;
                    }
                    stck.push(Convert.ToString(str[i]));
                }

                else
                {
                    value = value + str[i];
                }
            }

            if (str[str.Length - 1] != ')')
            {
                stck.push(value);
            }
            reOrder();
        }

        //stck goruntelemek icin kullanilir
        public void display()
        {
            stck.display();//display() metodu Stack sinifi nesnesinin metodudur.
        }

        //Olusturulacak stck nin boyutunu belirler.
        private int stckSize(string str)
        {
            int size = 0; //Isaretlerin sayisini tutar
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '+' || str[i] == '-' || str[i] == '/' || str[i] == '*' || str[i] == '(')
                {
                    size++;
                }
            }
            //Toplam stck boyutu isaretlerin 2 katinin 1 fazlasina esit olur.
            //Kapatma parantezi yukaridaki if icerisinde kontrol edilmemesinin sebebi formulun saglanmasidir.
            return 2 * size + 1;
        }

        //Sadece isarelerin degerini donderir
        private int singSize()
        {
            return (stackSize - 1) / 2;
        }

        //Stack elman siralamasini ters cevirir.
        private void reOrder()
        {
            Stack<string> temp1 = new Stack<string>(stck.size());
            Stack<string> temp2 = new Stack<string>(stck.size());

            while (!stck.isEmpty())
            {
                temp1.push(stck.pop());
            }

            while (!temp1.isEmpty())
            {
                temp2.push(temp1.pop());
            }

            while (!temp2.isEmpty())
            {
                stck.push(temp2.pop());
            }
        }

        //Parantezli islemler icin orderForPostfix() metodunu kullanarak Postfix deger hesaplar
        public void convertToPostfix()
        {
            while (!stck.isEmpty())
            {
                string temp = stck.pop();

                if (temp == "(")
                {
                    singStck.push(temp);
                }
                
                else if (temp == ")")
                {
                    string temp2 = singStck.pop();
                    
                    while (temp2 != "(")
                    {
                        posfixStck.push(temp2);
                        temp2 = singStck.pop();
                    }
                }

                else
                {
                    orderForPostfix(temp);
                }
            }

            while (!singStck.isEmpty())
            {
                posfixStck.push(singStck.pop());
            }

            while (!posfixStck.isEmpty())
            {
                stck.push(posfixStck.pop());
            }
        }

        //Islem onceligine gore postfix ifadeler olusturur.
        private void orderForPostfix(string str)
        {
            if (str == "+" || str == "-")
            {
                if (this.flag == true)
                {
                    string temp = null;
                    while (!singStck.isEmpty())
                    {  
                        temp = singStck.pop();
                        if (temp == "(")
                        {
                            singStck.push(temp);
                            break;
                        }
                        posfixStck.push(temp);                           
                    }
                    
                    singStck.push(str);
                }

                else
                {
                    singStck.push(str);
                }

                this.flag = false;
            }

            else if (str == "/" || str == "*")
            {
                singStck.push(str);
                this.flag = true;
            }

            else
            {
                posfixStck.push(str);
            }
        }

        //Olusturulan postfix ifadenin degerini hesaplar
        public void cal()
        {
            calculatePostfix(stck);
        }
    }
}
