namespace csharp_functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // c#-functions
            int[] array = {2, 6, 7, 5, 3, 9};
            // 1. Stampare l’array di numeri fornito a video
            StampaArray(array);

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




            Console.ReadKey();

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
        public static int Quadrato(int number){
            // return number * number;
            return (int)Math.Pow(number, 2); // eseguo un cast(int) perchè Math.Pow restituisce un double         
        }
        /*3)
        int[] ElevaArrayAlQuadrato(int[] array): che preso un array di numeri interi, restituisca un nuovo array con tutti gli elementi elevati quadrato. Attenzione: è importante restituire un nuovo array, e non modificare l’array come parametro della funzione! Vi ricordate perchè? Pensateci (vedi slide)
        */
        public static int[] ElevaArrayAlQuadrato(int[] array){
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
        public static int SommaElementiArray(int[] array){
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            
            }
            return sum;
        }                          
    }
}