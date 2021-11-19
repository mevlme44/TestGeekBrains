using System;

namespace TestGeekBrains
{
    class Polynomial
    {
        public int[] Multipliers;
        public int Length => Multipliers.Length;

        public Polynomial(int[] multipliers) {
            Multipliers = new int[multipliers.Length];

            for (int i = 0; i < Length; i++)
                Multipliers[i] = multipliers[i];
        }

        public Polynomial Product(Polynomial secondPolynomial) {
            Polynomial resultPolynomial = new Polynomial(new int[Length + secondPolynomial.Length - 1]);

            for (int i = 0; i < resultPolynomial.Length; i++) {
                resultPolynomial.Multipliers[i] = 0;

                for (int j = 0; j < Length; j++) {
                    for (int k = 0; k < secondPolynomial.Length; k++) {
                        if (i == k + j)
                            resultPolynomial.Multipliers[i] += Multipliers[j] * secondPolynomial.Multipliers[k];

                        if (k > i) break;
                    }

                    if (j > i) break;
                }

            }

            return resultPolynomial;
        }


        public override string ToString() {
            string tmp = "";
            for (int i = Length - 1 ; i >= 0; i--) {

                switch (i) {
                    case 0: tmp += String.Format("{0} {1}", Multipliers[i] > 0 ? "+" : "-", Math.Abs(Multipliers[i]).ToString());
                        break;
                    case 1: tmp += String.Format("{0} {1}x ", Multipliers[i] > 0 ? "+" : "-", Math.Abs(Multipliers[i]) == 1 ? "" : Math.Abs(Multipliers[i]).ToString());
                        break;
                    default: 
                        if (i == Length - 1) tmp += String.Format("{0}x^{1} ", Math.Abs(Multipliers[i]) == 1 ? "" : Multipliers[i].ToString(), i);
                        else tmp += String.Format("{2} {0}x^{1} ", Math.Abs(Multipliers[i]), i, Multipliers[i] > 0 ? "+" : "-");
                        break;
                }
            }

            return tmp;
        }
    }

    class Program
    {
        static void Main(string[] args) {
            Polynomial firstPolynomial = new Polynomial(new int[4] { -1, 1, 2, 1});
            Polynomial secondPolynomial = new Polynomial(new int[4] { 2, 1, 3, 4 });

            Console.WriteLine("\nFirst polynomial looks like this: " + firstPolynomial.ToString());
            Console.WriteLine("Second polynomial looks like this: " + secondPolynomial.ToString());
            Console.WriteLine("Product of two polynomial looks like this: " + firstPolynomial.Product(secondPolynomial).ToString());
        }
    }
}
