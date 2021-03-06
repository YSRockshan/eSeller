<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testForm.aspx.cs" Inherits="BzFlexer.SAMS.WebView.eCommerce.testForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>BizFlexer | Home </title>
    <link href="../BoostUnit/eCommerce/css/font.css" rel="stylesheet" />
    <link href="../BoostUnit/eCommerce/css/style.css" rel="stylesheet" />

    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script src="../BoostUnit/eCommerce/js/jquery.min.js"></script>
    <script src="../BoostUnit/eCommerce/js/easyResponsiveTabs.js"></script>
    <script src="../BoostUnit/eCommerce/js/login.js"></script>
    <script src="../BoostUnit/eCommerce/js/jquery.easing.1.1.js"></script>
    <script src="../BoostUnit/eCommerce/js/jquery.mousewheel.js"></script>
    <script src="../BoostUnit/eCommerce/js/jquery.contentcarousel.js"></script>

</head>
<body>

    <div>
        <body>
            <div class="header">
                <div class="wrap">
                    <div class="header-top">
                        <div class="header-left">
                            <div class="logo">
                                <a href="index.html">
                                    <img src="images/logo.png" alt="" /></a>
                            </div>
                            <div class="cssmenu">
                                <ul>
                                    <li class="active"><a href="index.html"><span>Home</span></a></li>
                                    <li><a href="products.html"><span>Products</span></a></li>
                                    <li><a href="services.html"><span>Services</span></a></li>
                                    <li class="has-sub"><a href="work.html"><span>My Work</span></a></li>
                                    <li class="last"><a href="contact.html"><span>Contact</span></a></li>
                                    <div class="clear"></div>
                                </ul>
                            </div>
                        </div>
                        <div class="header-right">
                            <div id="loginContainer">
                                <span>Sign In To BizFlexer</span><a id="loginButton"><img src="../BoostUnit/eCommerce/images/plus.png" alt="" /></a>
                                <div id="loginBox">
                                    <form id="loginForm" runat="server">

                                        <div>
                                            <span>
                                                <label>E-Mail</label></span>
                                            <span>
                                                <asp:TextBox ID="textBoxEmail" runat="server"></asp:TextBox></span>
                                            <%--<span><input id="textBoxEmail"  type="text" class="textbox"/></span>--%>
                                        </div>
                                        <div>
                                            <span>
                                                <label>Password</label></span>
                                            <span>
                                                <asp:TextBox ID="textBoxPassword" runat="server" TextMode="Password"></asp:TextBox></span>
                                            <asp:Label ID="labelErrorMessage" runat="server" Text="" CssClass="labelloginerror"></asp:Label>
                                            <%-- <span><input id="textBoxPassword"  type="password" class="textbox"/></span>--%>
                                        </div>
                                        <div>
                                            <span>
                                                <%-- <input type="submit" value="Subscribe"/>--%>
                                                <asp:Button ID="buttonLogin" runat="server" Text="Login" CssClass="button_Login"/>
                                                    <%--OnClick="buttonLogin_Click" />--%>
                                            </span>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="header-bottom">
                        <ul class="follow_icon">
                            <li><a href="#" style="opacity: 1;">
                                <img src="images/fb.png" alt=""></a></li>
                            <li><a href="#" style="opacity: 1;">
                                <img src="images/tw.png" alt=""></a></li>
                            <li><a href="#" style="opacity: 1;">
                                <img src="images/rss.png" alt=""></a></li>
                        </ul>
                        <div class="banner-img">
                            <img src="images/banner.png" alt="" />
                        </div>
                        <div class="clear"></div>
                    </div>
                </div>
            </div>
            <div class="main">
                <div class="wrap">
                    <div class="content-top">
                        <div class="cont span_2_of_3">
                            <h3>Lorem Ipsum is <span class="red">simply dummy text</span></h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat</p>
                        </div>
                        <div class="rsidebar span_1_of_3">
                            <img src="images/graph.png" alt="" />
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="content-middle">
                        <div class="our-mission" id="team">
                            <div id="ca-container" class="ca-container">
                                <div class="ca-wrapper">
                                    <div class="ca-item ca-item-1">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-2">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-3">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-4">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-5">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-6">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-7">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-8">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <script type="text/javascript">
                                $('#ca-container').contentcarousel();
                            </script>
                        </div>
                    </div>
                    <br>
                    <div class="content-middle-bottom">
                        <div class="our-mission" id="team1">
                            <div id="ca-container1" class="ca-container">
                                <div class="ca-wrapper">
                                    <div class="ca-item ca-item-1">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-2">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-3">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-4">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-5">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-6">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-7">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="ca-item ca-item-8">
                                        <div class="ca-item-main">
                                            <div class="ca-icon"></div>
                                            <h3><a href="#">Lorem ipsum dolor</a></h3>
                                            <h4>
                                                <span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna.</span>
                                            </h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- the jScrollPane script -->
                            <script type="text/javascript">
                                $('#ca-container1').contentcarousel();
                            </script>
                        </div>
                    </div>
                    <div class="bottom-content">
                        <div class="col_1_of_2 span_1_of_2">
                            <h3>Lorem Ipsum is <span class="red">simply dummy text</span></h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
                        </div>
                        <div class="col_1_of_2 span_1_of_2">
                            <h3>Lorem Ipsum is <span class="red">simply dummy text</span></h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="heading">
                        <h3>Lorem Ipsum is <span class="red">simply dummy text</span></h3>
                    </div>
                    <div class="sap_tabs">
                        <div id="horizontalTab2">
                            <ul class="resp-tabs-list">
                                <li>Comfort</li>
                                <li>Style</li>
                                <li>Design</li>
                                <li>Quality</li>
                                <div class="clear"></div>
                            </ul>
                            <div class="resp-tabs-container">
                                <div class="tab-1">
                                    <div class="tab-content">
                                        <div class="cont span_2_of_3">
                                            <h3>Lorem Ipsum is simply dummy text </h3>
                                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.</p>
                                        </div>
                                        <div class="rsidebar span_1_of_3">
                                            <img src="images/footer-banner.png" alt="" />
                                        </div>
                                        <div class="clear"></div>
                                    </div>
                                </div>
                                <div class="tab-2">
                                    <div class="tab-content">
                                        <div class="cont span_2_of_3">
                                            <h3>diam nonummy nibh euismod tincidunt</h3>
                                            <p>aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum</p>
                                        </div>
                                        <div class="rsidebar span_1_of_3">
                                            <img src="images/footer-banner.png" alt="" />
                                        </div>
                                        <div class="clear"></div>
                                    </div>
                                </div>
                                <div class="tab-3">
                                    <div class="tab-content">
                                        <div class="cont span_2_of_3">
                                            <h3>Lorem Ipsum is simply dummy text </h3>
                                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.</p>
                                        </div>
                                        <div class="rsidebar span_1_of_3">
                                            <img src="images/footer-banner.png" alt="" />
                                        </div>
                                        <div class="clear"></div>
                                    </div>
                                </div>
                                <div class="tab-4">
                                    <div class="tab-content">
                                        <div class="cont span_2_of_3">
                                            <h3>diam nonummy nibh euismod tincidunt</h3>
                                            <p>aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum</p>
                                        </div>
                                        <div class="rsidebar span_1_of_3">
                                            <img src="images/footer-banner.png" alt="" />
                                        </div>
                                        <div class="clear"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <script type="text/javascript">
                            $(document).ready(function () {
                                $('#horizontalTab2').easyResponsiveTabs({
                                    type: 'default', //Types: default, vertical, accordion           
                                    width: 'auto', //auto or any width like 600px
                                    fit: true   // 100% fit in a container
                                });
                            });
                        </script>
                    </div>
                </div>
            </div>
            <div class="footer">
                <div class="wrap">
                    <div class="bottom-content">
                        <div class="col_1_of_footer span_1_of_footer">
                            <div class="footer-logo">
                                <a href="index.html">
                                    <img src="images/logo.png" alt="" /></a>
                            </div>
                            <div class="footer-border">
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
                                <ul class="footer_icon">
                                    <li><a href="#" style="opacity: 1;">
                                        <img src="images/fb.png" alt=""></a></li>
                                    <li><a href="#" style="opacity: 1;">
                                        <img src="images/tw.png" alt=""></a></li>
                                    <li><a href="#" style="opacity: 1;">
                                        <img src="images/rss.png" alt=""></a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="col_1_of_footer span_1_of_footer1">
                            <div class="col_1_of_footer span_1_of_footer">
                                <div class="sidebar-nav">
                                    <div class="footer-middle-right">
                                        <h4>Pump Psd</h4>
                                        <ul>
                                            <li><a href="">Home</a></li>
                                            <li><a href="">Products</a></li>
                                            <li><a href="">Where to buy</a></li>
                                            <li><a href="">About Us</a></li>
                                            <li><a href="">Contact Us</a></li>
                                            <li><a href="">Join Newsletter</a></li>
                                            <li><a href="">Fake Content</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="col_1_of_footer span_1_of_footer">
                                <div class="sidebar-nav1">
                                    <div class="footer-right">
                                        <h4>About Us</h4>
                                        <ul>
                                            <li><a href="">Supporters</a></li>
                                            <li><a href="">Design</a></li>
                                            <li><a href="">Our Team</a></li>
                                            <li><a href="">Shoe Blog</a></li>
                                            <li><a href="">RSS</a></li>
                                            <li><a href="">Twitter</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="clear"></div>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="copy">
                        <p class="copy">© 2013 Designed by <a href="http://w3layouts.com" target="_blank">w3layouts</a> </p>
                    </div>
                </div>
            </div>
        </body>
    </div>

</body>
</html>
