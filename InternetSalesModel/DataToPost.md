### Company

```json
{
  "Name": "Company A"
}
```

```json
{
  "Name": "Company B"
}
```

### Items

```json
{
  "Name": "Product A",
  "Price": 10.99,
  "CompanyId": 1
}
```

```json
{
  "Name": "Product B",
  "Price": 15.99,
  "CompanyId": 2
}
```

```json
{
  "Name": "Product C",
  "Price": 20.49,
  "CompanyId": 1
}
```

```json
{
  "Name": "Product D",
  "Price": 12.79,
  "CompanyId": 2
}
```

### ShoppingCart

```json
{
  "ShoppingCartItems": [
    {
      "ItemId": 1,
      "Quantity": 2
    },
    {
      "ItemId": 2,
      "Quantity": 1
    }
  ]
}
```

### ShoppingCartItems

```json
{
  "ShoppingCartId": 1,
  "ItemId": 1,
  "Quantity": 2
}
```

```json
{
  "ShoppingCartId": 1,
  "ItemId": 2,
  "Quantity": 1
}
```


### Customer

```json
{
  "Name": "John Doe",
  "Address": "123 Main St",
  "Email": "john.doe@example.com"
}
```

```json
{
  "Name": "Jane Smith",
  "Address": "456 Elm St",
  "Email": "jane.smith@example.com"
}
```

### CreditCard

```json
{
  "CardNumber": "1234567812345678",
  "ExpirationDate": "01/25",
  "SecurityCode": "123",
  "CustomerId": 1
}
```

```json
{
  "CardNumber": "8765432187654321",
  "ExpirationDate": "03/27",
  "SecurityCode": "456",
  "CustomerId": 2
}
```


### Shipping

```json
{
  "Name": "Shipping A",
  "ShippingStatus": "Shipped"
}
```

```json
{
  "Name": "Shipping B",
  "ShippingStatus": "In Transit"
}
```

### Ecommerce

```json
{
  "Name": "Ecommerce A",
  "Address": "789 Oak St",
  "Email": "info@ecommerceA.com"
}
```

```json
{
  "Name": "Ecommerce B",
  "Address": "101 Pine St",
  "Email": "info@ecommerceB.com"
}
```

### Orders

```json
{
  "OrderDate": "2024-05-30T12:00:00",
  "Status": "Pending",
  "OrderNumber": "ORD001",
  "CustomerId": 1
}
```

```json
{
  "OrderDate": "2024-05-30T12:00:00",
  "Status": "Pending",
  "OrderNumber": "ORD002",
  "CustomerId": 2
}
```

### OrderItems

```json
{
  "OrderId": 1,
  "ItemId": 1,
  "Price": 10.99,
  "Quantity": 2
}
```

```json
{
  "OrderId": 2,
  "ItemId": 2,
  "Price": 15.99,
  "Quantity": 1
}
```