using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Program;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------- Nivel 1 - EX1");
            Console.WriteLine(ClassifyNumber(5));
            Console.WriteLine(ClassifyNumber(-3));
            Console.WriteLine(ClassifyNumber(0));
            Console.WriteLine("---------------- Nivel 1 - EX2");
            Console.WriteLine(CanDrive(16, true));
            Console.WriteLine(CanDrive(18, false));
            Console.WriteLine(CanDrive(25, true));
            Console.WriteLine(CanDrive(18, true));

            Console.WriteLine("---------------- Nivel 2 - EX1");
            var numbers = new List<int>
                {
                    -2,
                    5,
                    10,
                    -1,
                    0,
                    8
                };

            Console.WriteLine(CountPositiveNumbers(numbers));

            Console.WriteLine("---------------- Nivel 2 - EX2");
            var values = new List<decimal>
                {
                    10,
                    -5,
                    20,
                    0,
                    15
                };

            Console.WriteLine(CalculateTotal(values));

            Console.WriteLine("---------------- Nivel 3 - EX1");

            var orders = new List<Order>
            {
                new Order { Total = 150, Paid = false },
                new Order { Total = 50, Paid = false },
                new Order { Total = 300, Paid = true },
                new Order { Total = 200, Paid = false },
                new Order { Total = 100, Paid = false }
            };

            Console.WriteLine(CountPendingOrders(orders));


            Console.WriteLine("---------------- Nivel 3 - EX2");
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Ana" },
                new Customer { Id = 2, Name = "Bruno" },
                new Customer { Id = 3, Name = "Carla" }
            };


            Console.WriteLine(FindCustomerById(customers, 2)?.Name);
            // Bruno

            Console.WriteLine(FindCustomerById(customers, 10)?.Name);
            // não imprime nome porque devolve null

            Console.WriteLine("---------------- Nivel 3 - EX3");
            var products = new List<Product>
            {
                new Product { Name = "Keyboard", Price = 50, Active = true },
                new Product { Name = "Mouse", Price = 0, Active = true },
                new Product { Name = "Monitor", Price = 200, Active = false },
                new Product { Name = "Laptop", Price = 900, Active = true }
            };

            var newProducts = GetAvailableProducts(products);

            foreach (var item in newProducts)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("---------------- Nivel 4 - EX1");
            var validItems = new List<OrderItem>
            {
                new OrderItem { Reference = "A001", Quantity = 2 },
                new OrderItem { Reference = "B002", Quantity = 1 }
            };

            Console.WriteLine(IsValidOrder(validItems));

            Console.WriteLine("---------------- Nivel 4 - EX2");
            Console.WriteLine(CanAccessSystem(true, false, 0));

            Console.WriteLine("---------------- Nivel 4 - EX3");
            Console.WriteLine(IsEligibleForDiscount(150, true, true));    // True
            Console.WriteLine(IsEligibleForDiscount(150, false, false));  // True
            Console.WriteLine(IsEligibleForDiscount(150, false, true));   // False
            Console.WriteLine(IsEligibleForDiscount(50, true, false));    // False

            Console.WriteLine("---------------- Nivel 5 - EX1");
            Console.WriteLine(IsValidUser(new User
            {
                Username = "ricardo",
                Age = 25,
                Active = true,
                Blocked = false
            })); // True

            Console.WriteLine(IsValidUser(new User
            {
                Username = "",
                Age = 25,
                Active = true,
                Blocked = false
            })); // False

            Console.WriteLine(IsValidUser(new User
            {
                Username = "ricardo",
                Age = 17,
                Active = true,
                Blocked = false
            })); // False

            Console.WriteLine(IsValidUser(new User
            {
                Username = "ricardo",
                Age = 25,
                Active = false,
                Blocked = false
            })); // False

            Console.WriteLine(IsValidUser(new User
            {
                Username = "ricardo",
                Age = 25,
                Active = true,
                Blocked = true
            })); // False

            Console.WriteLine("---------------- Nivel 5 - EX2");
            Console.WriteLine(CalculateShipping(new NewOrder
            {
                Total = 150,
                IsPremiumCustomer = false
            })); // 0

            Console.WriteLine(CalculateShipping(new NewOrder
            {
                Total = 50,
                IsPremiumCustomer = true
            })); // 0

            Console.WriteLine(CalculateShipping(new NewOrder
            {
                Total = 50,
                IsPremiumCustomer = false
            })); // 5

            Console.WriteLine(CalculateShipping(new NewOrder
            {
                Total = 0,
                IsPremiumCustomer = false
            })); // 0


            Console.WriteLine("---------------- Nivel 5 - EX3");
            var items = new List<SaleItem>
            {
                new SaleItem
                {
                    Name = "Keyboard",
                    Price = 50,
                    Quantity = 2,
                    Active = true
                },
                new SaleItem
                {
                    Name = "Mouse",
                    Price = 20,
                    Quantity = 3,
                    Active = false
                },
                new SaleItem
                {
                    Name = "Monitor",
                    Price = 200,
                    Quantity = 1,
                    Active = true
                },
                new SaleItem
                {
                    Name = "Cable",
                    Price = 0,
                    Quantity = 5,
                    Active = true
                }
            };

            Console.WriteLine(CalculateOrderTotal(items));

        }

        /*Nivel 1 - EX1
        O que tenho: Tenho um número inteiro
        O que quero obter: Quero saber se é positivo, negativo ou zero
        Regras: Se for menor que 0 é negativo, se for maior que 0 é positivo, senão é 0
        Primeira decisão: Ler se é um número válido e maior que 0
         */
        static string ClassifyNumber(int number)
        {
            if (number > 0)
                return "Positive";
            else if (number < 0)
                return "Negative";
            else
                return "Zero";
        }

        /*Nivel 1 - EX2
        O que tenho: Tenho a idade do condutor e um booleano a dizer se tem carta ou não
        O que quero obter: Quero saber se a pessoa pode conduzir (true ou false)
        Regras: Idade igual ou superior a 18 e ter a carta de condução. As duas condições têm de ser verdadeiras
        Primeira decisão: Verificar idade é maior ou igual a 18
        */
        static bool CanDrive(int age, bool hasLicense)
        {
            if (age >= 18 && hasLicense)
                return true;

            return false;
        }

        /*Nivel 2 - EX1
        Input:Uma lista de números inteiros
        Output: Retorna quantidade de nºinteiros maiores que 0 que tem na lista
        Rules: Só são validos os numeros maioes que 0
        First step: Percorrer cada valor da lista
        What do I need to store while processing: Só são válidos os números maiores que 0
        When does that stored value change?: Quando encontro na lista um valor > que 0
        */
        static int CountPositiveNumbers(List<int> numbers)
        {
            int contador = 0;

            foreach (var item in numbers)
            {
                if (item > 0)
                    contador++;
            }
            return contador;
        }

        /*Nivel 2 - EX2
        Input:Uma lista de números inteiros
        Output: O reusltado da soma dos numeros positivos maiores que 0
        Rules: Somar apenas os valores superiores a 0
        First step: Percorrer cada valor da lista
        What do I need to store while processing: Preciso guardar a soma dos números > 0
        When does that stored value change?: Quando ao percorrer um item da lista, esse item é um número
        */
        static decimal CalculateTotal(List<decimal> values)
        {

            decimal soma = 0.0m;

            foreach (var item in values)
            {
                if (item > 0)
                    soma += item;
            }

            return soma;
        }

        /*Nivel 3 - EX1
        Input: Uma lista de objetos de encomendas
        Output: Retorna a quantidade de encomendas não pagas e total maior que 100
        Rules: Total > 100 e paid == false
        First step: Percorrer a lista dos objetos orders
        What do I need to store while processing: Uma variável que conte o número de encomendas que cumprem as regras.
        When does that stored value change?: Quando encontra uma encomenda que cumpra as Rules
        What must be true for one order to count?: Valor do total ser maior que 100 e não estar paga
        */
        public class Order
        {
            public decimal Total { get; set; }
            public bool Paid { get; set; }
        }

        static int CountPendingOrders(List<Order> orders)
        {
            int conta = 0;

            foreach (var item in orders)
            {
                if (item.Total > 100 && !item.Paid)
                    conta++;
            }
            return conta;
        }

        /*Nivel 3 - EX2
        Input: Uma lista de clientes
        Output: O objeto Customer cujo Id corresponde ao id recebido. Se não existir, retorna null.
        Rules: - Percorrer a lista
               - Comparar o Id de cada cliente com o id recebido
               - Se encontrar, devolver esse Customer
               - Se não encontrar nenhum, devolver null
        First step: Percorrer cada cliente da lista
        What do I need to store while processing: Nada. Posso devolver o Customer imediatamente quando o encontrar. 
        When can I stop processing? Quando encontra um cliente com o mesmo id que foi pedido
        What happens if I reach the end without finding anything? retorna null
        */
        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        static Customer FindCustomerById(List<Customer> customers, int id)
        {
            foreach (var item in customers)
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        /*Nivel 3 - EX3
         * Input: Lista de produtos
         * Output: Retorna os produtos que estão ativos e preço > 0
         * Rules: Active == true
         *        Price > 0
         * First step: Percorrer a lista de produtos
         * What do I need to store while processing? Uma lista dos produtos que cumpres as regras
         * When does that stored value change? quando encontra um produto que cumpra as regras
         * Can I stop when I find the first valid product? Why? Não. Porque as regras não especificam que 
         *  deve ser só um artigo ou qualquer outro critério de paragem
        */
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public bool Active { get; set; }
        }
        static List<Product> GetAvailableProducts(List<Product> products)
        {

            List<Product> availableProducts = new List<Product>();

            foreach (var item in products)
            {
                if (item.Active && item.Price > 0)
                    availableProducts.Add(item);
            }
            return availableProducts;
        }

        /*Nivel 4 - EX1
         * Input: Lista de items
         * Output: um booleano se a encomenda está válida ou não
         * Rules: 1. Tiver pelo menos um artigo
                  2. Todos os artigos tiverem Reference preenchida
                  3. Todos os artigos tiverem Quantity > 0
         * First step: Verificar se existe pelo menos um item.
         * What do I need to store while processing? Nada.
         * When can I stop processing? Assim que encontrar um item inválido.
         * What is enough to make the entire order invalid? Um único item com Quantity <= 0 ou Reference vazia.
         * What happens if the list is empty? A encomenda é inválida, portanto retorno false.
        */
        public class OrderItem
        {
            public string Reference { get; set; }
            public int Quantity { get; set; }
        }

        static bool IsValidOrder(List<OrderItem> items)
        {
            if (items.Count == 0)
                return false;

            foreach (var item in items)
            {
                if (item.Quantity <= 0 || string.IsNullOrWhiteSpace(item.Reference))
                    return false;
            }

            return true;
        }

        /*Nivel 4 - EX2
         *Valid when:- isActive == true
                     - isBlocked == false
                     - failedAttempts < 3
         As 3 variáveis têm de cumprir estes valores
         *Invalid when: - isActive == false
                        - isBlocked == true
                        - failedAttempts >= 3
         Basta uma destas condições ser verdadeira para o acesso ser inválido.
         *Boolean expression: Validar com oprador &&
         */
        static bool CanAccessSystem(bool isActive, bool isBlocked, int failedAttempts)
        {
            return isActive && !isBlocked && failedAttempts < 3 && failedAttempts >= 0;
        }

        /*Nivel 4 - EX3
         * Valid when: Total >= 100 E (IsPremium true ou hasDebt false) 
         * Invalid when: Total < 100 ou (IsPremium false e hasDebt true)
         * Which condition is grouped?: IsPremium true ou hasDebt false
         * Boolean expression: validar com operadores && e ||
        */
        static bool IsEligibleForDiscount(decimal total, bool isPremium, bool hasDebt)
        {
            return total >= 100 && (isPremium || !hasDebt);
        }

        /*Nivel 5 - EX1
         * Valid when:Username ativo, preenchido e não bloqueado com idade >= 18
         * Invalid when: Alguma das condições anterior não se comprovarem
         * Can I return false early? Why? Sim. Basta uma única condição inválida para o utilizador inteiro ser inválido.
         * Boolean expression: !IsNullOrWhiteSpace(Username) && Age >= 18 && Active
        */
        public class User
        {
            public string Username { get; set; }
            public int Age { get; set; }
            public bool Active { get; set; }
            public bool Blocked { get; set; }
        }
        static bool IsValidUser(User user)
        {
            return !string.IsNullOrWhiteSpace(user.Username) && user.Age >= 18 && user.Active && !user.Blocked;
        }

        /* Nivel 5 - EX2
        * Input: Uma encomenda
        * Output: Valor dos portes de envio
        * Rules: - Se Total <= 0 → portes = 0
                 - Se Total >= 100 → portes = 0
                 - Se o cliente for Premium → portes = 0
                 - Caso contrário → portes = 5
        * First step: verificar Total e se é premium 
        * What do I need to store while processing? NAda
        * Can I return early? Why? Se Total > 0, Total < 100 e o cliente não for Premium, já sei que os portes são 5 e posso devolver imediatamente.
        * What conditions result in shipping = 0? 
                - Total <= 0 OU - Total >= 100 OU - IsPremiumCustomer == true
        * What happens if none of those conditions are true? portes = 5
        */
        public class NewOrder
        {
            public decimal Total { get; set; }
            public bool IsPremiumCustomer { get; set; }
        }

        static decimal CalculateShipping(NewOrder order)
        {
            if (order.Total > 0 && order.Total < 100 && !order.IsPremiumCustomer)
                return 5.0m;
            return 0;
        }

        /* Nivel 5 - EX3
        * Input: Lista de vendas
        *
        * Output:soma de todos as vendas válidas
        *
        * Rules:
        *- Só entram na soma artigos Active == true
         - Price tem de ser > 0
         - Quantity tem de ser > 0
         - Para cada artigo válido:
                subtotal = Price * Quantity
        - O resultado é a soma de todos os subtotais válidos
        *
        * First step: Criar uma variável total iniciada a 0 e percorrer os artigos.
        *
        * What do I need to store while processing? Uma variável com o total acumulado dos artigos válidos.
        *
        * When does that stored value change? Quando existe uma venda com um artigo válido
        *
        * What makes one item valid? Tem de estar Active == true, Price > 0 e Quantity > 0
        *
        * What do I do when an item is invalid? Não calcula o subtotal
        *
        * Can I return early? Why? Sim, se a lista estiver vazia
        */
        public class SaleItem
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public bool Active { get; set; }
        }

        static decimal CalculateOrderTotal(List<SaleItem> items)
        {

            decimal total = 0.0m;

            foreach (var item in items)
            {
                if (item.Active && item.Price > 0 && item.Quantity > 0)
                    total += item.Price * item.Quantity;
            }

            return total;
        }



    }
}
