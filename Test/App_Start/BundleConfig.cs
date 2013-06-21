using System.Web;
using System.Web.Optimization;

namespace Test
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new StyleBundle("~/bundles/Create").Include(
                "~/js/jquery.ui.widget.min.js",
                "~/js/jquery.ui.mouse.min.js",
                "~/js/jquery.ui.slider.min.js"
                ));
        }
    }
}