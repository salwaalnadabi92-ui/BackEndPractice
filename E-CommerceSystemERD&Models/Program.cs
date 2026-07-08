using E_CommerceSystemERD_Models.modles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace E_CommerceSystemERD_Models
{
    public class Program

    {

        public static ECommerceContext context = new ECommerceContext();

   
        //1 register user
        public static void RegisterUser()
        {
            Console.WriteLine("=== Register New User ===");

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter password: ");
            string passwordHash = Console.ReadLine();

            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter phone number (optional, press Enter to skip): ");
            string phone = Console.ReadLine();

            Console.Write("Enter address (optional, press Enter to skip): ");
            string address = Console.ReadLine();


            User newUser = new User()// add new user object

            {
                username = username,
                email = email,
                passwordHash = passwordHash,
                fullName = fullName,
                phoneNumber = string.IsNullOrWhiteSpace(phone) ? null : phone,
                address = string.IsNullOrWhiteSpace(address) ? null : address,
                registrationDate = DateTime.Now,
                isActive = true
            };

            context.users.Add(newUser);
            context.SaveChanges();

            Console.WriteLine("User registered successfully. Assigned ID:" + newUser.userId);
        }



        //2:NewProducToCategoy
        public static void NewProducToCategory()
        {

            var displayCategories = context.categories.ToList();//dispaly all category

            foreach (var category in displayCategories)
            {
                Console.WriteLine("categoryId:" + category.categoryId + "| categoryName :" + category.categoryName + "| description:" + category.description + "|  imageUrl:" + category.imageUrl);
            }

            Console.WriteLine("Enter category id: ");//read catogroy selection
            int categoryId = int.Parse(Console.ReadLine());

            Category categorySelection = context.categories.FirstOrDefault(c => c.categoryId == categoryId);

            if (categorySelection == null)
            {
                Console.WriteLine("category not found");
                return;

            }
            //read all product details from user
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter description (optional): ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter product price (optional): ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter stock quantity: ");
            int stockQuantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter image Url: ");
            string imageUrl = Console.ReadLine();


            Product newProduct = new Product//add new object
            {
                productName = productName,
                description = description,
                price = price,
                stockQuantity = stockQuantity,
                categoryId = categoryId,
                createdAt = DateTime.Now,
                isAvailable = true
            };

            context.Products.Add(newProduct);
            context.SaveChanges();


            Console.WriteLine("=== Product added to category successfully ===");
            Console.WriteLine("User ID: " + newProduct.productId);
        }


        //3 :place an order

        //public static void placeOrder()
 



        //4 writeproductreview
        public static void WriteProductReview()
        {

            foreach (User user in context.users)
            {
                Console.WriteLine("UserId:" + user.userId + "| Username :" + user.username + "| PasswordHash:" + user.passwordHash + "|FullName :" + user.fullName +

                    "PhoneNumber :" + user.phoneNumber + "|Address:" + user.address + "|RegistrationDate :" + user.registrationDate + "|IsActive:" + user.isActive
                    );
            

                Console.WriteLine("Enter user id");
                int userId = int.Parse(Console.ReadLine());

            }


            foreach (Product product in context.Products)
                {

                Console.WriteLine("productId:" + product.productId + "| productName :" + product.productName + "| description :" + product.description + "|stockQuantity  :" + product.stockQuantity); 
 

            }

            Console.WriteLine("Enter product id");
            int productId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter product id");
            int rate= int.Parse(Console.ReadLine());

            Console.WriteLine("Enter product id");
            string comment =(Console.ReadLine());


            Review newreview = new Review
            {

                
                productId = productId,
                rating=   rate  ,
                 comment=  comment  ,
                reviewDate = DateTime.Now,

            };
            
            context.Reviews.Add(newreview);

            context.SaveChanges();

        }


        //5 update product
        public static void updateProduct()

        {
            Console.WriteLine(" enter product id");
            int productId= int.Parse(Console.ReadLine());

            var product=context.Products.FirstOrDefault(p => p.productId == productId);

            if (product == null)
            {
                Console.WriteLine("product id not found");
                return;
            }

            Console.WriteLine("enter new price");
            decimal price= decimal.Parse(Console.ReadLine());

            Product updateProduct = new Product
            {
                price = price,
                isAvailable = false,

            };

            context.Products.Add(updateProduct);
            context.SaveChanges();

            Console.WriteLine("update successfuly");
            Console.WriteLine(" The new price: "+price );
           
        }



        //6: cancel order

        public static void cencelOrder()
        {

            Console.WriteLine(" enter order id");
            int orderId = int.Parse(Console.ReadLine());

            var order = context.Orders.FirstOrDefault(o => o.orderId == orderId);

            if (order == null)
            {
                Console.WriteLine(" id not found");
                return;
            }

            var loadOrder = context.OrderItems.Where(O => O.orderId == orderId).ToList();

            foreach (var item in loadOrder)
            {

                var relatedProduct = context.Products.FirstOrDefault(p => p.productId == item.productId);

                if (relatedProduct == null)
                {
                    Console.WriteLine(" product id not found ");
                    return;
                }

                relatedProduct.stockQuantity += item.quantity;
            }

            order.status = "cancelled";

        }


        //7 delete review 

        public static void deleteReview()
        {

            Console.WriteLine(" enter review id");
            int reviewId= int.Parse(Console.ReadLine());

            var review = context.Reviews.FirstOrDefault(r=>r.reviewId==reviewId);
             if(review == null)
            {
                Console.WriteLine("review id not found ");
                return ;
            }

             context.Reviews.Remove(review);
             context.SaveChanges();
             Console.WriteLine(" The review  was deleted successfuly");

        }


        //8 view all product 
        public static void viewAllProduct()
        {
            var product = context.Products.ToList();


            foreach (var item in product)
            {

                Console.WriteLine("productId:" + item.productId + "| productName :" + item.productName + "| description :" + item.description + "|stockQuantity  :" + item.stockQuantity + "|imageUrl:" + item.imageUrl + "|categoryId :" + item.categoryId + "|createdAt:" + item.createdAt + "|isAvailable:" + item.isAvailable);

            }
        }

       //9 filter product by category and price range 

        public static void fliterProduct()
        {
              
            Console.WriteLine("enter category id ");
            int categoryId= int.Parse(Console.ReadLine());


            Console.WriteLine("enter minimum price");
            decimal   minPrice = decimal.Parse(Console.ReadLine());

             Console.WriteLine("enter maxmum price");
            decimal maxPrice = decimal.Parse(Console.ReadLine());

            var fliter=context.Products.Where(p=>p.categoryId==categoryId  && p.price ==minPrice&& p.price==maxPrice)
                                       .OrderBy(p => p.price)
                                        .ToList();

            foreach(var item in fliter)
            {
                Console.WriteLine("dispaly :" + fliter);
            }

            context.SaveChanges();
         
        }


        //10 :  get category with all its product


        public static void getCategory()
        {
            Console.WriteLine("enter  category id ");
            int categoryId=int.Parse(Console.ReadLine());

            var category =context.categories
                .Include(c=>c.Products)
                .FirstOrDefault(C=>C.categoryId==categoryId);

            Console.WriteLine("category name :"+ category.categoryName);
            Console.WriteLine("description :" + category.description);


            Console.WriteLine("___ All product___");

            foreach(var item in category.Products)
            {
                Console.WriteLine(item.productName);

            }

                            
        }








        static void Main(string[] args)
        {


            bool exit = false;

            while (exit == false)
            {

                Console.WriteLine("------------------------------------");
                Console.WriteLine("THE BUSINESS SERVICES");
                Console.WriteLine(" ___________________________________");
                Console.WriteLine("1.Register a New User");
                Console.WriteLine("2.Add a New Product to a Category");
                Console.WriteLine("3.Place an Order");
                Console.WriteLine("4.Write a Product Review .");
                Console.WriteLine("5.Update Product Price and Availability");
                Console.WriteLine("6.Cancel an Order");
                Console.WriteLine("7.Delete a Review");
                Console.WriteLine("8.View All Products(Get All)");
                Console.WriteLine("9.Filter Products by Category and Price Range ");
                Console.WriteLine("10.Get Category with All Its Products");
                Console.WriteLine("11.View Order History with Full Details");
                Console.WriteLine("12.12 Product Summary Report");
                Console.WriteLine("0.Exit");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1:

                        RegisterUser();


                        break;

                    case 2:
                        NewProducToCategory();



                        break;

                    case 3:
                        


                        break;

                    case 4:

                        WriteProductReview();

                        break;

                    case 5:
                    updateProduct();

                        break;

                    case 6:

                    cencelOrder();

                        break;

                    case 7:

                        deleteReview();


                        break;
                    case 8:

                            viewAllProduct();

                        break;

                    case 9:

                        fliterProduct();

                        break;

                    case 10:

                        getCategory();

                        break;

                    case 11:

                        break;

                    case 12:

                        break;




                    case 0:
                        exit = true;

                        break;

                    default:
                        Console.WriteLine("invaild");
                        break;

                }//switch


                Console.WriteLine("Enter any key");

                Console.ReadKey();
                Console.Clear();


            }//while

















        }
    }
}
