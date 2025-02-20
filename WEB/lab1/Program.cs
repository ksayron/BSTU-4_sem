//����������� ���� �������
namespace lab1
{
    //�������� ����� ���������
    public class Program
    {
        //��������� ������� ������� � ���������
        public static void Main(string[] args)
        {
            //�������������� ������ ������,��������� ��������� ������������ � ���������� ������ ��� ����������
            var builder = WebApplication.CreateBuilder(args);
            //���������� ������ http ����������� � ������ ��������� �����������
            builder.Services.AddHttpLogging(o => { });
            //������� ���������� �� ������ �������������
            var app = builder.Build();

            //����������� ���������� �� ������������� HtttpLogging middleware
            app.UseHttpLogging();
            //����������� ����� �� GET ������
            app.MapGet("/", () => "��� ������ ASPA");

            //��������� ����������
            app.Run();
        }
    }
}
