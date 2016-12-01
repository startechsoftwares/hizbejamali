<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="StyleAndScript.ascx.vb" Inherits="Hizbe_Jamali_Web.StyleAndScript" %>
<!-- Link to the site's main CSS style -->
<link rel="stylesheet" type="text/css" media="screen" href='<%= ResolveUrl("~/css/style.css")%>' />
<!-- Link to the Superfish menu CSS style -->
<link rel="stylesheet" type="text/css" media="screen" href='<%= ResolveUrl("~/css/superfish.css")%>' />
<!-- Link to the Nivo Slider CSS style -->
<link rel="stylesheet" type="text/css" media="screen" href='<%= ResolveUrl("~/css/nivo-slider.css")%>' />
<!-- Link to the Pretty Photo CSS style -->
<link rel="stylesheet" type="text/css" media="screen" href='<%= ResolveUrl("~/css/prettyPhoto.css")%>' />
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
<!-- Cufon scripts -->
<script type="text/javascript" src='<%= ResolveUrl("~/js/cufon-yui.js")%>'></script>
<script type="text/javascript" src='<%= ResolveUrl("~/js/ScriptMT_700.font.js")%>'></script>
<script type="text/javascript" src='<%= ResolveUrl("~/js/Androgyne_400.font.js")%>'></script>
<!-- Superfish scripts -->
<script type="text/javascript" src='<%= ResolveUrl("~/js/hoverIntent.js")%>'></script>
<script type="text/javascript" src='<%= ResolveUrl("~/js/superfish.js")%>'></script>
<!-- Nivo Slider script -->
<script src='<%= ResolveUrl("~/js/jquery.nivo.slider.pack.js")%>' type="text/javascript"></script>
<!-- Custom JS script -->
<script src='<%= ResolveUrl("~/js/custom.js")%>' type="text/javascript"></script>
<!-- PrettyPhoto script -->
<script src='<%= ResolveUrl("~/js/jquery.prettyPhoto.js")%>' type="text/javascript"></script>
<!-- Define which elements should be replaced with Cufon -->
<script type="text/javascript">
    Cufon.replace('#header #right_section ul.top_navigation li a.menulink', { fontFamily: 'Androgyne', hover: 'true', textShadow: '1px 1px 1px #fff' });
    Cufon.replace('h1', { fontFamily: 'ScriptMT', textShadow: '1px 1px 1px #fff' });
    Cufon.replace('h2', { fontFamily: 'ScriptMT', textShadow: '1px 1px 1px #fff' });
</script>
<!-- Superfish menu options -->
<script type="text/javascript">
    $(document).ready(function () {
        $("ul.top_navigation").superfish();
        $('#slider').nivoSlider();
        $("a[rel^='prettyPhoto']").prettyPhoto();
    });
</script>