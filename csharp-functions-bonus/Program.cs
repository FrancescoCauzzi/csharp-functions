namespace csharp_functions
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // c#-functions
            Console.Write("Inserisci un numero che corrisponde alla lunghezza dell'array che vuoi generare: ");
            int arrayLength = GetIntInput();
            Console.WriteLine("Digita i numeri che vuoi inserire nell'array");
            int[] array = ReturnArrayOfUserSpecifiedElements(arrayLength);
            // 1. Stampare l’array di numeri fornito a video
            StampaArray(array);
            Console.WriteLine();
            // 2. Stampare l’array di numeri fornito a video, dove ogni numero è stato prima elevato al quadrato (Verificare che l’array originale non sia stato modificato quindi ristampare nuovamente l’array originale e verificare che sia rimasto [2, 6, 7, 5, 3, 9])
            int[] arrayEx2 = ElevaArrayAlQuadrato(array);
            Console.Write("L' array originale è: ");
            StampaArray(array);
            Console.Write("L'array modificato è: ");
            StampaArray(arrayEx2);

            // 3. Stampare la somma di tutti i numeri
            int somma = SommaElementiArray(array);
            Console.Write("La somma degli elementi dell'array di partenza é: " + somma);

            Console.WriteLine();

            // 4. Stampare la somma di tutti i numeri elevati al quadrati
            int sommaQuadrati = SommaElementiArray(arrayEx2);
            Console.Write("La somma degli elementi dell'array con gli elementi elevati al quadrato é: " + sommaQuadrati);
            Console.WriteLine();

            // Esercizi extra
            // 1.
            Console.WriteLine("Inserisci un numero di cui vuoi calcolare il fattoriale");
            int factNumber = GetIntInput();
            int factorial = GetFactorial(factNumber);
            Console.Write($"Il fattoriale di {factNumber} è: {factorial}");
            Console.ReadKey();

            // 2.
            Console.WriteLine("Inserisci il numero della posizione dell'elemento della sequenza di Fibonacci che ti interessa");
            int fiboPosition = GetIntInput();
            int fiboElement = GetNthFibonacciNumberRecursive(fiboPosition);
            Console.WriteLine($"{fiboElement}");
            Console.ReadKey();
        }

        /* BONUS         
         */
        public static int[] ReturnArrayOfUserSpecifiedElements(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                int userInput = GetIntInput();
                array[i] = userInput;
            }
            return array;
        }

        public static int GetIntInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.WriteLine("Input non valido. Iserisci un numero intero.");
            }
        }

        /*1) 
        void StampaArray(int[] array): che preso un array di numeri interi, stampa a video il contenuto dell’array in questa forma “[elemento 1, elemento 2, elemento 3, ...]”. Potete prendere quella fatta in classe questa mattina
        */
        public static void StampaArray(int[] array)
        {
            Console.Write("[");

            for (int i = 0; i < array.Length; i++)
            {
                if (i < array.Length - 1)
                {
                    Console.Write(array[i] + ", ");
                }
                else
                {
                    Console.Write(array[i]);
                }
            }

            Console.WriteLine("]");

        }
        /*2)
        int Quadrato(int numero): che vi restituisca il quadrato del numero passato come parametro.
        */
        public static int Quadrato(int number)
        {
            // return number * number;
            return (int)Math.Pow(number, 2); // eseguo un cast(int) perchè Math.Pow restituisce un double         
        }
        /*3)
        int[] ElevaArrayAlQuadrato(int[] array): che preso un array di numeri interi, restituisca un nuovo array con tutti gli elementi elevati quadrato. Attenzione: è importante restituire un nuovo array, e non modificare l’array come parametro della funzione! Vi ricordate perchè? Pensateci (vedi slide)
        */
        public static int[] ElevaArrayAlQuadrato(int[] array)
        {
            // make a clone of the array
            int[] arrayCloned = array.Clone() as int[];
            for (int i = 0; i < arrayCloned.Length; i++)
            {
                arrayCloned[i] = Quadrato(arrayCloned[i]);

            }
            return arrayCloned;
        }
        /*
        4)
        int sommaElementiArray(int[] array): che preso un array di numeri interi, restituisca la somma totale di tutti gli elementi dell’array.
        */
        public static int SommaElementiArray(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];

            }
            return sum;
        }

        /*Esercizi extra (funzioni ricorsive)
        Una funzione che, dato un numero intero n > 0, ne calcoli il fattoriale                      
        */
        public static int GetFactorial(int number)
        {
            // n! = n * (n-1)!
            // caso base
            if (number == 1)
            {
                return number;
            }
            else
            {
                return number * GetFactorial(number - 1);
            }

        }
        /*Esercizi extra (funzioni ricorsive)
        Una funzione che, dato un numero intero n >= 0, restituisca l'n-esimo elemento della sequenza di Fibonacci.                      
        */
        public static int GetNthFibonacciNumberNonRecursive(int position)
        {
            //  1. Initialize a = 0, b = 1
            int a = 0;
            int b = 1;
            // 2. For i from 1 to n-1
            for (int i = 0; i < position - 1; i++)
            {
                //     1. Calculate nextFib = a + b
                //     2. Update a = b and b = nextFib
                int nextFib = a + b;
                a = b;
                b = nextFib;
            }

            // 3. Return b as the nth Fibonacci number
            return b;
        }

        // Fibonacci ricursiva
        // Fₙ = Fₙ₋₁ + Fₙ₋₂
        public static int GetNthFibonacciNumberRecursive(int position)
        {
            // Fibonacci(n)
            // 1. If n == 0 or n == 1
            if (position == 0 | position == 1)
            {
                return position;
            }
            else
            {
                // 2. Else
                //     1. Return Fibonacci(n-1) + Fibonacci(n-2)
                return GetNthFibonacciNumberRecursive(position - 1) + GetNthFibonacciNumberRecursive(position - 2);
            }
        }
    }
}