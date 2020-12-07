# ProcessJsonRequestDemo
```
{"Code":200,"Orders":[{"FruitName":"xxx花東產西瓜xxx"}]}
{"Code":200,"Orders":[{"3CName":"iPhone  X 64GB"}]}
```
如果向另一廠商取得訂單記錄的json格式如上, 由於屬性名稱是FruitName, 3CName,無法簡單的轉型為同一個型別

我練習的程式是
1. 寫一個Facade object取得上述Json,並轉型為屬性具備 FruitName, 3CName 的UpStreamOrderItem objet
2. 在 Adapter object裡使用 Simple Factory , 將 UpStreamOrderItem 轉型為 OrderItem
3. 寫支 OrderService 叫用 Adapter object 取得本程式需要的強型別物件

解析結果:

![](Assets/result.png)