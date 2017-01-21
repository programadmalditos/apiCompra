using System.Linq;


public static class DbInitzializer
{

    public static void Initzialize(ListaCompraConext context)
    {
        if (context.Compra.Any())
        {
            return;
        }

        var productos = new Compra[]{
    new Compra(){
        
        Nombre="Leche",
        Descripcion="Para el cafe",
        Unidades=1,
        Precio=0.7M
    },
new Compra(){
        
        Nombre="Jamon",
        Descripcion="Para el desayuno",
        Unidades=3,
        Precio=5M
    },
};
        foreach (var compra in productos)
        {
            context.Compra.Add(compra);
        }
        context.SaveChanges();

    }
}