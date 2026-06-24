Description

This project is a WPF desktop application developed as part of a learning journey to practice modern .NET desktop development concepts. It demonstrates the implementation of the MVVM (Model-View-ViewModel) architectural pattern, data binding, command handling, navigation between views, data validation, and dependency injection.

The application simulates a simple coffee shop management system, allowing users to manage customer information and browse product data. Sample customers and products are loaded asynchronously from local data providers to demonstrate data-driven UI development.

Features
View and manage a list of customers.
Search and filter customers in real time.
Add new customers through a user-friendly interface.
Edit customer details with two-way data binding.
Delete selected customers.
Navigate seamlessly between Customers and Products views.
Display product information in a read-only WPF DataGrid.
Automatically update the UI using INotifyPropertyChanged.
Validate user input using INotifyDataErrorInfo.
Implement a clean MVVM architecture with separate Models, ViewModels, Views, Commands, and Data Providers.
Utilize Dependency Injection through Microsoft.Extensions.DependencyInjection.
Load data asynchronously to improve responsiveness and demonstrate modern asynchronous programming practices.
