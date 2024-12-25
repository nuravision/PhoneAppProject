using PhoneApp.Controller;
using PhoneApp.Helpers.Enums;
PersonController controller = new PersonController();
while (true)
{
    GetMenues();
    Console.Write("Enter operation choice:");
    Operation:  string operationStr=Console.ReadLine();
    int operation;
    bool isCorrectOperation=int.TryParse(operationStr, out operation);
    if (isCorrectOperation)
    {
        switch (operation) {
            case (int)OperationTypes.Create:
                controller.Create();
                break;
            case (int)OperationTypes.Delete:
                controller.Delete();
                break;
            case (int)OperationTypes.Edit:
                controller.Edit();
                break;
            case (int)OperationTypes.GetAll:
                controller.GetAll();
                break;
            case (int)OperationTypes.Sort:
                controller.Sorting();
                break;
            case (int)OperationTypes.Search:
                Console.WriteLine("Search");
                break;
            default:
                Console.WriteLine("Operation not found,please select again:");
                goto Operation;
                break;
        }
    }
    else
    {
        Console.WriteLine("Operation format is wrong,please select again:");
        goto Operation;
    }
}
static void GetMenues()
{
    Console.WriteLine("1-Create Contact  2-Delete Contact  3-Edit Contact  4-Get All Contacts  5-Sort 6-Search");
}