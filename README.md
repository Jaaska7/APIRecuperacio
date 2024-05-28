# API de Ventas en Línea

## Descripción del Proyecto

Este proyecto es una API para un modelo de ventas en línea desarrollado en C# utilizando Entity Framework. El objetivo es gestionar las entidades y relaciones de un sistema de ventas por internet, permitiendo operaciones CRUD (Crear, Leer, Actualizar, Eliminar) y otras funcionalidades específicas.

## Entidades del Modelo ER

El modelo ER tiene las siguientes entidades:

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
- **Item**
- **Order**
- **Shopping Cart**

### Funcionalidades Adicionales

1. **Agregar Item a Order y Shopping Cart**:
   - Implementar la funcionalidad para añadir un item a un pedido (Order) y a un carrito de compras (Shopping Cart).

2. **Calcular el Total de un Producto**:
   - A partir de un código de producto, se debe calcular el total de unidades vendidas y el precio total que representan estas unidades. Esta información debe obtenerse a partir de las relaciones con **Order** y **Shopping Cart**.

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