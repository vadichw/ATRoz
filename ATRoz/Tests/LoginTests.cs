using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using ATRoz.PageObjects; // ���������, ��� ������������ ���� ���������

namespace ATRozTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]

    public class LoginTest : PageTest
    {

    }
}




