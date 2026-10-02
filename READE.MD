Câu 1:
- Value Types (Kiểu giá trị):
Cơ chế lưu trữ: Lưu trữ trực tiếp giá trị thực sự trong vùng nhớ Stack (hoặc lưu trong Heap nếu nó là trường dữ liệu - field của một class).
Gồm có: Các kiểu dữ liệu nguyên thủy (int, float, double, bool, char), struct, enum.
Hành vi gán/sao chép: Khi gán một Value Type cho biến khác, C# sẽ tạo một bản sao hoàn chỉnh của giá trị đó. Việc thay đổi ở biến này không làm ảnh hưởng đến biến kia.
Quản lý bộ nhớ: Được thu hồi/giải phóng bộ nhớ tự động ngay khi biến ra khỏi phạm vi (scope) hoạt động.

- Reference Types (Kiểu tham chiếu):
Cơ chế lưu trữ: Lưu trữ địa chỉ tham chiếu (con trỏ/address) trên Stack, còn dữ liệu/đối tượng thực sự được lưu trữ trong vùng nhớ Heap.
Gồm có: class, interface, delegate, string, array, object.
Hành vi gán/sao chép: Khi gán một Reference Type cho biến khác, C# chỉ sao chép địa chỉ tham chiếu chứ không sao chép đối tượng. Cả hai biến đều trỏ tới cùng một đối tượng trên Heap, nên thay đổi qua biến này sẽ phản ảnh trên biến kia.
Quản lý bộ nhớ: Do Trình thu gom rác của .NET (Garbage Collector - GC) tự động quản lý và giải phóng khi không còn biến nào tham chiếu tới đối tượng.

Câu 2: Tính năng Init-only Properties (init) trong C# 9/10
Sự khác biệt với set thông thường:
Thuộc tính có set: Có thể thay đổi/gán lại giá trị cho thuộc tính ở bất kỳ thời điểm nào trong suốt vòng đời của đối tượng.
Thuộc tính có init: Chỉ cho phép khởi tạo giá trị một lần duy nhất tại thời điểm khởi tạo đối tượng (thông qua constructor hoặc cú pháp Object Initializer new Object { Property = value }). Sau khi đối tượng đã khởi tạo xong, thuộc tính này sẽ trở thành chỉ đọc (read-only) và không thể sửa đổi giá trị.

Trường hợp sử dụng thực tế:
Dùng khi thiết kế các đối tượng Bất biến (Immutable Objects) hoặc Data Transfer Objects (DTO), Value Objects trong mô hình DDD.
Đảm bảo tính toàn vẹn của dữ liệu (tránh vô tình bị thay đổi giá trị sau khi tạo) nhưng vẫn giữ được sự linh hoạt khi khởi tạo bằng Object Initializer thay vì phải viết các constructor dài dòng chứa nhiều tham số.

Câu 3: Phân biệt phương thức virtual ở lớp cha và phương thức override ở lớp con
Phương thức virtual (ở lớp cha):
Cho biết phương thức này có một triển khai mặc định (default implementation) ở lớp cha, đồng thời cho phép (mở đường cho) các lớp con có quyền định nghĩa lại (ghi đè) nó nếu cần.
Lớp con không bắt buộc phải viết lại phương thức virtual. Nếu lớp con không ghi đè, nó sẽ dùng lại logic mặc định của lớp cha.

Phương thức override (ở lớp con):
Được sử dụng ở lớp con để thay thế hoàn toàn logic của phương thức virtual (hoặc abstract) từ lớp cha.
Đa hình (Polymorphism): Khi một biến kiểu lớp cha trỏ đến một thể hiện của lớp con, việc gọi phương thức này tại thời điểm thực thi (runtime) sẽ kích hoạt phiên bản được override ở lớp con chứ không gọi phương thức virtual của lớp cha (Late Binding / Dynamic Binding).

Câu 4: Tại sao thành phần static không thể truy xuất qua một thể hiện (Object Instance) tạo bởi new?
Cơ chế: Thành phần static (biến, phương thức, thuộc tính) thuộc về bản thân Lớp (Class level) chứ không thuộc về bất kỳ thể hiện cụ thể nào (Instance level).
Vùng nhớ: Thành phần static được khởi tạo duy nhất một lần và lưu trữ trong vùng nhớ tĩnh (Type metadata/Type Object) ngay khi Lớp được nạp vào bộ nhớ (.NET AppDomain). Trong khi đó, toán tử new cấp phát bộ nhớ trên Heap cho từng thể hiện riêng biệt.
Nguyên tắc thiết kế C#: C# bắt buộc gọi thành phần static thông qua Tên_Lớp (ClassName.StaticMember) để tránh sự mơ hồ (ambiguity), tăng tính rõ ràng cho mã nguồn (giúp lập trình viên phân biệt rõ đâu là dữ liệu dùng chung toàn cục của lớp, đâu là dữ liệu riêng của từng đối tượng).
