using System.Web;
using System.Web.Optimization;

namespace GestionServiceBatiment.ASP
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"
            //          ));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                      "~/Scripts/assets/vendor/jquery/jquery.min.js",
                      "~/Scripts/assets/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/Scripts/assets/vendor/jquery.easing/jquery.easing.min.js",
                      "~/Scripts/assets/vendor/php-email-form/validate.js",
                      "~/Scripts/assets/vendor/waypoints/jquery.waypoints.min.js",
                      "~/Scripts/assets/vendor/isotope-layout/isotope.pkgd.min.js",
                      "~/Scripts/assets/vendor/venobox/venobox.min.js",
                      "~/Scripts/assets/vendor/owl.carousel/owl.carousel.min.js",
                      "~/Scripts/assets/vendor/aos/aos.js",
                      "~/Scripts/assets/js/main.js"

                      //"~/Scripts/assets/vendor/jquery/jquery.min.js",
                      //"~/Scripts/assets/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      //"~/Scripts/assets/vendor/jquery.easing/jquery.easing.min.js",
                      //"~/Scripts/assets/vendor/php-email-form/validate.js",
                      //"~/Scripts/assets/vendor/isotope-layout/isotope.pkgd.min.js",
                      //"~/Scripts/assets/vendor/venobox/venobox.min.js",
                      //"~/Scripts/assets/vendor/waypoints/jquery.waypoints.min.js",
                      //"~/Scripts/assets/vendor/owl.carousel/owl.carousel.min.js",
                      //"~/Scripts/assets/js/main.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/assets/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/assets/vendor/icofont/icofont.min.css",
                      "~/Content/assets/vendor/boxicons/css/boxicons.min.css",
                      "~/Content/assets/vendor/remixicon/remixicon.css",
                      "~/Content/assets/vendor/venobox/venobox.css",
                      "~/Content/assets/vendor/owl.carousel/assets/owl.carousel.min.css",
                      "~/Content/assets/vendor/fontawesome/all.min.css",
                      "~/Content/assets/vendor/aos/aos.css",
                      "~/Content/assets/css/style.css",
                      "~/Content/site.css"

            //"~/Content/bootstrap.css",
            //"~/Content/assets/vendor/bootstrap/css/bootstrap.min.css",
            //"~/Content/assets/vendor/icofont/icofont.min.css",
            //"~/Content/assets/vendor/boxicons/css/boxicons.min.css",
            //"~/Content/assets/vendor/animate.css/animate.min.css",
            //"~/Content/assets/vendor/remixicon/remixicon.css",
            //"~/Content/assets/vendor/venobox/venobox.css",
            //"~/Content/assets/vendor/owl.carousel/assets/owl.carousel.min.css",
            //"~/Content/assets/css/style.css",
            // "~/Content/site.css"
            ));
        }
    }
}