using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac

{    //Autofac kullanarak bağımlılık enjeksiyonu için bir yapılandırma modülü 
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Birisi senden IProductService isterse ona bir ProductManager instance'ı ver. 
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            //uygulama boyunca IProductDal talep edildiğinde hep aynı EfProductDal örneği kullanılacak
        }
    }
}
