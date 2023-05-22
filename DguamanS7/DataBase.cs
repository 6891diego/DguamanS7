using System;
using System.Collections.Generic;
using System.Text;
using SQLite;//utilizar los metodos de la base de datos

namespace DguamanS7
{
    internal interface DataBase
    {
        //creamos el metodo
        SQLiteAsyncConnection GetConnection();//define el metodo de coneccion

    }
}
