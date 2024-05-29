# API de Ventas en Línea

## Descripción del Proyecto

Este proyecto consiste en una API para un modelo de ventas en línea desarrollado en C# utilizando Entity Framework. El objetivo es gestionar las entidades y relaciones de un sistema de ventas por internet, permitiendo operaciones CRUD (Crear, Leer, Actualizar, Eliminar) y otras funcionalidades específicas.

## Entidades del Modelo ER

El modelo Entidad-Relación tiene las siguientes entidades:

1. **Customer (Cliente)**:
   - Atributos: Name (Nombre), Address (Dirección), Email (Correo Electrónico)

2. **Item (Producto)**:
   - Atributos: Name (Nombre), Price (Precio)

3. **Order (Pedido)**:
   - Atributos: OrderNumber (Número de Pedido)

4. **Shopping Cart (Carrito de Compras)**

5. **Company (Compañía)**:
   - Atributos: Name (Nombre)

6. **Shipping (Envío)**

7. **Credit Card (Tarjeta de Crédito)**

8. **E-Commerce (Comercio Electrónico)**

## Relación entre las Entidades

- Un **Customer** tiene una relación opcional con **Credit Card** (un cliente puede o no tener una tarjeta de crédito).
- Un **Customer** puede hacer múltiples **Orders** (pedidos).
- Un **Order** contiene múltiples **Items**.
- Un **Shopping Cart** contiene múltiples **Items**.
- Un **Item** es producido por una **Company**.
- Un **Customer** puede interactuar con **Shipping** para el envío de **Items**.

## Funcionalidades del API

### CRUD para Entidades

Desarrollaremos operaciones CRUD (Crear, Leer, Actualizar, Eliminar) para las siguientes entidades:
- **Customer**
- **Item**
- **Order**
- **Shopping Cart**
- **Company**
- **Shipping**
- **Credit Card**
- **E-Commerce**

### Funcionalidades Adicionales

1. **Agregar Item a Order y Shopping Cart**:
   - Se ha implementado la capacidad de agregar un ítem a un pedido (Order) y a un carrito de compras (Shopping Cart) utilizando las respectivas API endpoints.
     - En el caso de OrderItems, se pueden agregar, modificar y eliminar elementos de la orden.
     - Para ShoppingCartItems, se han implementado las operaciones de agregar, modificar y eliminar elementos del carrito de compras.

2. **Calcular el Total de un Producto**:
   - Se ha añadido una nueva acción en el controlador de OrderItems (`GetItemStats`) que calcula el total de unidades vendidas y el ingreso total generado por un producto específico a partir de su `ItemId`. Este endpoint devuelve un JSON con la información requerida.

3. **Obtener Total de un Pedido**:
   - Se ha implementado una funcionalidad para obtener el total de un pedido, considerando la suma de los precios de todos los ítems incluidos en el pedido.

4. **Actualizar Estado del Pedido**:
   - Se ha añadido la capacidad de actualizar el estado de un pedido mediante una solicitud HTTP, lo que permite cambiar el estado de un pedido de "pendiente" a "completado", por ejemplo.

5. **Obtener Pedidos por Cliente**:
   - Se ha implementado una función para obtener todos los pedidos asociados a un cliente específico. Esto permite a los usuarios ver su historial de pedidos y realizar un seguimiento de sus compras anteriores.

## Tecnologías Utilizadas

- C#
- Entity Framework
- SQL Server (o cualquier base de datos compatible con Entity Framework)

## Configuración del Proyecto

1. Clona este repositorio.
2. Configura la cadena de conexión a tu base de datos en el archivo de configuración.
3. Ejecuta las migraciones de Entity Framework para crear la base de datos.
4. Ejecuta el proyecto.

## Ejecución de Pruebas

Para ejecutar las pruebas, utiliza el comando específico para pruebas en tu entorno de desarrollo. Asegúrate de tener configuradas las dependencias necesarias para ejecutar las pruebas unitarias.

## Contribuciones

Las contribuciones son bienvenidas. Por favor, abre un "issue" para discutir los cambios que deseas realizar antes de hacer un "pull request".

## Licencia

Este proyecto está licenciado bajo la MIT License. Para más detalles, consulta el archivo LICENSE en el repositorio.