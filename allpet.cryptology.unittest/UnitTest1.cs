using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System.Threading.Tasks;

namespace allpet.cryptology.unittest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSign1K()
        {
            //init data;
            Logger.LogMessage("begin testsign1000");
            byte[] testdata = new byte[4096];
            System.Random ran = new System.Random();

            System.DateTime begin = System.DateTime.Now;
            var prikey = new byte[32];
            ran.NextBytes(prikey);
            var signer = Allpet.Helper_NEO.Signer.FromPriKey(prikey);
            //Parallel.For(0, 10000, (i) =>
            for (var i = 0; i < 1000; i++)
            {
                  var signdata = signer.Sign(testdata);

              }
            //);
            System.DateTime end = System.DateTime.Now;
            Logger.LogMessage("end testsign1000:" + (end - begin).TotalSeconds);

        }
        [TestMethod]
        public void TestVerfitySign1K()
        {
            //init data;
            Logger.LogMessage("begin testsign1000");
            byte[] testdata = new byte[4096];
            System.Random ran = new System.Random();

            System.DateTime begin = System.DateTime.Now;
            var prikey = new byte[32];
            ran.NextBytes(prikey);
            var signer = Allpet.Helper_NEO.Signer.FromPriKey(prikey);
            var pubkey = Allpet.Helper_NEO.GetPublicKey_FromPrivateKey(prikey);
            var signdata = signer.Sign(testdata);
            var unsigner = Allpet.Helper_NEO.Signer.FromPubkey(pubkey);
            var vi = 0;
            //Parallel.For(0, 10000, (i) =>
            for (var i = 0; i < 1000; i++)
            {
                var b = unsigner.Verify(testdata, signdata);
                if (b)
                    vi++;

            }
            //);

            System.DateTime end = System.DateTime.Now;
            Logger.LogMessage("end testunsign1000:" + (end - begin).TotalSeconds);
            Logger.LogMessage("end testunsign1000 vi=" + vi);

        }

        [TestMethod]
        public void TestSign10KParallel()
        {
            //init data;
            Logger.LogMessage("begin testsign1000");
            byte[] testdata = new byte[4096];
            System.Random ran = new System.Random();

            System.DateTime begin = System.DateTime.Now;
            var prikey = new byte[32];
            ran.NextBytes(prikey);
            var signer = Allpet.Helper_NEO.Signer.FromPriKey(prikey);
            Parallel.For(0, 10000, (i) =>
            {
                var signdata = signer.Sign(testdata);

            });
            //for (var i = 0; i < 1000; i++)
            //{
            //    //ran.NextBytes(testdata);


            //}
            System.DateTime end = System.DateTime.Now;
            Logger.LogMessage("end testsign1000:" + (end - begin).TotalSeconds);

        }
        [TestMethod]
        public void TestVerfitySign10KParallel()
        {
            //init data;
            Logger.LogMessage("begin testsign1000");
            byte[] testdata = new byte[4096];
            System.Random ran = new System.Random();

            System.DateTime begin = System.DateTime.Now;
            var prikey = new byte[32];
            ran.NextBytes(prikey);
            var signer = Allpet.Helper_NEO.Signer.FromPriKey(prikey);
            var pubkey = Allpet.Helper_NEO.GetPublicKey_FromPrivateKey(prikey);
            var signdata = signer.Sign(testdata);
            var unsigner = Allpet.Helper_NEO.Signer.FromPubkey(pubkey);
            var vi = 0;
            Parallel.For(0, 10000, (i) =>
            {
                var b = unsigner.Verify(testdata, signdata);
                if (b)
                    vi++;

            });

            System.DateTime end = System.DateTime.Now;
            Logger.LogMessage("end testunsign1000:" + (end - begin).TotalSeconds);
            Logger.LogMessage("end testunsign1000 vi=" + vi);

        }

    }
}
