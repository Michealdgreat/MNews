# MNews
# MNN - Modern News Network Viewer

## Project Description
MNN (Modern News Network Viewer) is an ASP.NET MVC application designed to display news articles fetched from the NewsOrg API. The application's interface is inspired by CNN, ensuring a high level of readability and ease of navigation. MNN utilizes ViewComponents to manage the UI components and to filter news content effectively, making the user experience both intuitive and responsive.

## Key Features
- **Dynamic News Display**: Articles are dynamically fetched using HTTP GET requests from the NewsOrg API.
- **CNN-inspired UI**: The user interface mimics the CNN website for a familiar and user-friendly browsing experience.
- **Efficient Filtering**: Articles can be filtered directly through the UI, allowing users to find news that matches their interests quickly.
- **Service Layer Architecture**: All business logic related to data fetching and operations is handled centrally in the service layer.
- **Modular ViewComponents**: Uses ViewComponents for a clean and maintainable codebase, promoting reusability and separation of concerns.


## Configuration Details

Before you can run the MNN application, it's essential to configure some key settings, including securing and setting up an API key from NewsOrg. Follow these detailed steps to ensure your application is set up correctly:

### 1. Obtain API Key
You'll need an API key from NewsOrg to fetch news articles:

- Visit the NewsOrg API's official website and register for an account.
- Navigate to your dashboard on the NewsOrg website and generate a new API key.

### 2. Setup Environment Variables
Using environment variables is a secure way to manage your API key without hardcoding it into your source code:

- **For Development in Visual Studio:**
  - Open your project in Visual Studio.
  - Right-click on your project in the Solution Explorer and select "Properties".
  - Navigate to the "Debug" tab.
  - Find the "Environment variables" section and add a new entry:
    - Name: `NewsApiKey`
    - Value: `<Your NewsOrg API key>`
  - Save your changes by clicking "Save".

### 3. Accessing the API Key in Your Application
Here’s how you can access the API key in your ASP.NET MVC project:

```csharp
public class NewsService
{
    private readonly IConfiguration _configuration;
    
    public NewsService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetApiKey()
    {
        return _configuration.GetValue<string>("NewsApiKey");
    }
}

## License
MNN is released under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support
For support, please open an issue through the GitHub Issue Tracker associated with this repository.

## Acknowledgements
- Thanks to the NewsOrg API for providing the news data that powers our application.
- Gratitude to the ASP.NET MVC framework for enabling a robust application architecture.

