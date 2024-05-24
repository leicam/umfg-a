using TreasuryChallenge.Old;

namespace TresasuryCharllenge.Test
{
    [TestClass]
    public class ProgramTest
    {

        [TestMethod]
        [TestCategory("Teste Validacão")]
        [Owner ("Alunos 5ª Periodo")]
        public void TestMethod1()
        {
            try
            {
                var codigo = CodeGenerate.GetLine();
                Assert.IsNotNull(codigo);
                Assert.AreEqual(7,codigo.Length);

            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
           
        }
    }
}