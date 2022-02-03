using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using mvctrial2.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace mvctrial2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private ServiceProvider serviceProvider;
        public App()
        {


            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

        } 

        private void ConfigureServices(ServiceCollection services)
        {
            //could also do 
            
            services.AddSingleton<ISingletonOperation,DefaultOperation>();
            
        }
        public ServiceProvider GetService()
        {
            return this.serviceProvider;
           // var singletonOperation = serviceProvider.GetService<ISingletonOperation>();
            
        }
        
    }
}
