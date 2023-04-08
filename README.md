# FunBooksAndVideos

This is a basic POC code developed for the E-comm(FunBooksAndVideos) application using SOLID principles, Chain of responsibility pattern , Repository pattern, 
Exception handling and Logging with Swagger configuration for testing the endpoints. 

## Requirements

To run the application locally, you will need the following:

    1. Visual Studio 2022 
    2. .NET Core 6.0 SDK 
## Run Locally

1. Clone the project

```bash
  git clone https://github.com/SaiThirunagiri/FunBooksAndVideos.git
```

2. Go to the project directory

```bash
  cd my-project
```

3. Open the solution file FunBooksAndVideos.sln in Visual Studio

4. Run the application by pressing F5 or by selecting Debug > Start Debugging from the menu.

5. The application should launch in your default web browser at https://localhost:7232/swagger/index.html, where port is the port number assigned by Visual Studio.




## Usage
### Retrieving all Customers
1. Unfold the "/api/Customer/GetAllCustomer" pannel.
2. Click on "Try out" button
3. Click on "Execute" Button 
4. in the "Responses" section you will get the list of predefined customer details will be shown in the screen. 
![image](https://user-images.githubusercontent.com/76816861/230737812-c2d70815-1206-430c-96d1-08feab055133.png)

### Retrieving a Customer data
1. Unfold the "/api/Customer/GetCustomer" pannel.
2. Click on "Try out" button
3. Enter "1" customerId text box
3. Click on "Execute" Button 
4. in the "Responses" section the details for the customer are displayed. 
![image](https://user-images.githubusercontent.com/76816861/230737947-e389bdb6-03e2-4138-8045-18af1e3a0a65.png)

### Register a new Customer 
1. Unfold the "/api/Customer/RegisterCustomer" pannel.
2. Click on "Try out" button
3. Enter Customer ID , Name, Address in the Json 
3. Click on "Execute" Button 
4. The new customer is added to the inmemory collection repository. 
5. Now perform "Retrieving all Customers" or "Retrieving a Customer data" for verification.

### Purchase Order
1. Unfold the "/api/PurchaseOrders" pannel.
2. Click on "Try out" button
3. Enter data as specified in the Json
3. Click on "Execute" Button 
4. The Purchase order process will excecute both Member ship and shipping rules accordingly. 

## Contributing

Contributions are welcome! If you would like to contribute to this project, please fork the repository and submit a pull request with your changes


## License

[MIT](https://choosealicense.com/licenses/mit/)

