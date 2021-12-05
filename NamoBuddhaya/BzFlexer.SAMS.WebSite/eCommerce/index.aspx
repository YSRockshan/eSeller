<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BzFlexer.SAMS.WebView.eCommerce.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eSeller | Home </title>



    <link href="../BoostUnit/eCommerce/css/font.css" rel="stylesheet" />
    <%--<link href="../BoostUnit/eCommerce/css/nbstyle.css" rel="stylesheet" />--%>
    <link href="../BoostUnit/eCommerce/css/NBstyle.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <%--  <script src="../BoostUnit/eCommerce/js/jquery.min.js"></script>
    <script src="../BoostUnit/eCommerce/js/easyResponsiveTabs.js"></script>--%>
    <%-- <script src="../BoostUnit/eCommerce/js/login.js"></script>--%>
    <%--  <script src="../BoostUnit/eCommerce/js/jquery.easing.1.1.js"></script>
    <script src="../BoostUnit/eCommerce/js/jquery.mousewheel.js"></script>
    <script src="../BoostUnit/eCommerce/js/jquery.contentcarousel.js"></script>--%>




    <%--<link href="css/style.css" rel="stylesheet" type="text/css" media="all" />--%>
    <%-- <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script src="js/easyResponsiveTabs.js" type="text/javascript"></script>
    <script src="js/login.js"></script>
    <%-- <link href="css/StyleSheet1.css" rel="stylesheet" />--%>
    <link href='http://fonts.googleapis.com/css?family=Droid+Sans' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Roboto' rel='stylesheet' type='text/css'>
    <!-- the jScrollPane script -->
    <script type="text/javascript" src="js/jquery.easing.1.3.js"></script>
    <!-- the jScrollPane script -->
    <script type="text/javascript" src="js/jquery.mousewheel.js"></script>
    <script type="text/javascript" src="js/jquery.contentcarousel.js"></script>

</head>
<body>
    <%--start header--%>
    <div class="header">
        <div class="wrap">
            <div class="header-top">
                <div class="header-left">
                    <div class="logo">
                        <a href="#">
                            <img src="../BoostUnit/eCommerce/images/BizFlexer logo.png" /></a>
                    </div>
                    <div class="cssmenu">
                        <ul>
                            <li class="active"><a href="index.aspx"><span>Home</span></a></li>
                            <li><a href="#products"><span>Products</span></a></li>
                            <li><a href="#services"><span>Services</span></a></li>
                            <li><a href="#goal"><span>Goal</span></a></li>
                            <li class="last"><a href="#about"><span>About</span></a></li>
                            <div class="clear"></div>
                        </ul>
                    </div>
                </div>
                <div class="header-right">
                    <div id="loginContainer">
                        <span>Sign In To eSeller</span><a id="loginButton"><img src="../BoostUnit/eCommerce/images/plus.png" alt="" /></a>
                        <div id="loginBox">
                            <%-- style="display: block;"--%>
                            <form id="loginForm" runat="server">

                                <div>
                                    <span>
                                        <label>E-Mail</label></span>
                                    <span>
                                        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox></span>
                                    <%--<span><input id="textBoxEmail"  type="text" class="textbox"/></span>--%>
                                </div>
                                <div>
                                    <span>
                                        <label>Password</label></span>
                                    <span>
                                        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox></span>
                                    <asp:Label ID="LabelNotification" runat="server" Text="" CssClass="labelloginerror"></asp:Label>
                                    <%-- <span><input id="textBoxPassword"  type="password" class="textbox"/></span>--%>
                                </div>
                                <div>
                                    <span>
                                        <%-- <input type="submit" value="Subscribe"/>--%>
                                        <asp:Button ID="buttonLogin" runat="server" Text="Login" CssClass="button_Login"
                                            OnClick="buttonLogin_Click" />

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
                        <img src="../BoostUnit/eCommerce/images/fb.png" alt="" /></a></li>
                    <li><a href="#" style="opacity: 1;">
                        <img src="../BoostUnit/eCommerce/images/tw.png" alt="" /></a></li>
                    <li><a href="#" style="opacity: 1;">
                        <img src="../BoostUnit/eCommerce/images/rss.png" alt="" /></a></li>
                </ul>
                <div class="banner-img">
                    <img src="../BoostUnit/eCommerce/images/banner.png" alt="" />
                </div>
                <div class="clear"></div>
            </div>
        </div>
    </div>
    <%--end header--%>


    <%--start container--%>
    <div class="main">
        <div class="wrap">
            <div class="content-top">
                <div id="products" class="cont span_2_of_3">
                    <h3>Best products from <span class="red">Fathima Trade Centre</span></h3>
                    <p>Often the main attraction in your home or office is the furniture. Provided of course it is elegantly designed and matches with the overall interior design. When choosing the right kind of furniture for a particular space, it is imperative that you take in to account the 3 C’s that are synonymous with furniture- comfort, color and contours.</p>

                    <p>A stunning combination of classic, modern and contemporary, our home furniture makes an impressive addition to your modern homes. With plethora of beds, sofas, Dining & Bar decor, chairs, tables, cabinets, kid’s furniture and seating,  fulfill your furniture needs here at Fathima Trade Centre.</p>
                </div>
                <div class="rsidebar span_1_of_3">
                    <img src="../BoostUnit/eCommerce/images/graph.png" alt="" />
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
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-2">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-3">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-4">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-5">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-6">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-7">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-8">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
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
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-2">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-3">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-4">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-5">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-6">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-7">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
                                    </h4>
                                </div>
                            </div>
                            <div class="ca-item ca-item-8">
                                <div class="ca-item-main">
                                    <div class="ca-icon"></div>
                                    <h3><a href="#">Comfort Style Design Quality</a></h3>
                                    <h4>
                                        <span>Get it all in one convenient place when you fulfill your  furniture needs here at Fathima Trade Centre.</span>
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
            <%--<div class="bottom-content">
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
	      </div>--%>
            <div id="services" class="heading">
                <h3>Why?<span class="red">Fathima Trade Centre.</span></h3>
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
                                    <h3>Best products from <span class="red">Fathima Trade Centre</span></h3>
                                    <p>Often the main attraction in your home or office is the furniture. Provided of course it is elegantly designed and matches with the overall interior design. When choosing the right kind of furniture for a particular space, it is imperative that you take in to account the 3 C’s that are synonymous with furniture- comfort, color and contours.</p>
                                </div>
                                <div class="rsidebar span_1_of_3">
                                    <img src="../BoostUnit/eCommerce/images/Footer-Banner-Samsung-Galaxy-8-top.jpg" alt="" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="tab-2">
                            <div class="tab-content">
                                <div class="cont span_2_of_3">
                                    <h3>Best products from <span class="red">Fathima Trade Centre</span></h3>

                                    <p>A stunning combination of classic, modern and contemporary, our home furniture makes an impressive addition to your modern homes. With plethora of beds, sofas, Dining & Bar decor, chairs, tables, cabinets, kid’s furniture and seating,  fulfill your furniture needs here at Fathima Trade Centre.</p>
                                </div>
                                <div class="rsidebar span_1_of_3">
                                    <img src="../BoostUnit/eCommerce/images/Footer-Banner-Samsung-Galaxy-8-top.jpg" alt="" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="tab-3">
                            <div class="tab-content">
                                <div class="cont span_2_of_3">
                                    <h3>Best products from <span class="red">Fathima Trade Centre</span></h3>

                                    <p>A stunning combination of classic, modern and contemporary, our home furniture makes an impressive addition to your modern homes. With plethora of beds, sofas, Dining & Bar decor, chairs, tables, cabinets, kid’s furniture and seating,  fulfill your furniture needs here at Fathima Trade Centre.</p>
                                </div>
                                <div class="rsidebar span_1_of_3">
                                    <img src="../BoostUnit/eCommerce/images/footer-banneFooter-Banner-Samsung-Galaxy-8-top.jpg" alt="" />
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                        <div class="tab-4">
                            <div class="tab-content">
                                <div class="cont span_2_of_3">
                                    <h3>Best products from <span class="red">Fathima Trade Centre</span></h3>
                                    <p>Often the main attraction in your home or office is the furniture. Provided of course it is elegantly designed and matches with the overall interior design. When choosing the right kind of furniture for a particular space, it is imperative that you take in to account the 3 C’s that are synonymous with furniture- comfort, color and contours.</p>

                                </div>
                                <div class="rsidebar span_1_of_3">
                                    <img src="../BoostUnit/eCommerce/images/Footer-Banner-Samsung-Galaxy-8-top.jpg" alt="" />
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
    <%--end container--%>


    <%--start footer--%>
    <div class="footer">
        <div class="wrap">
            <div class="bottom-content">
                <div class="col_1_of_footer span_1_of_footer">
                    <div id="goal" class="footer-logo">
                        <a href="index.aspx">
                            <img src="../BoostUnit/eCommerce/images/BizFlexer logo foo.png" alt="" /></a>
                    </div>
                    <div class="footer-border">
                        <p>“eSeller” is a web based solution for managing sales agents and sales transactions. It can be linked with some sales functions and inventory functions to increase the competitive advantages.</p>
                        <ul class="footer_icon">
                            <li><a href="#" style="opacity: 1;">
                                <img src="../BoostUnit/eCommerce/images/fb.png" alt="" /></a></li>
                            <li><a href="#" style="opacity: 1;">
                                <img src="../BoostUnit/eCommerce/images/tw.png" alt="" /></a></li>
                            <li><a href="#" style="opacity: 1;">
                                <img src="../BoostUnit/eCommerce/images/rss.png" alt="" /></a></li>
                        </ul>
                    </div>
                </div>



                <div class="col_1_of_footer span_1_of_footer1">
                    <div class="col_1_of_footer span_1_of_footer">
                        <div class="sidebar-nav">
                            <div class="footer-middle-right">
                                <h4>eSeller</h4>
                                <ul>
                                    <li><a href="#">Home</a></li>
                                    <li><a href="#products">Products</a></li>
                                    <li><a href="#services">Services</a></li>
                                    <li><a href="#goal">Goal</a></li>
                                    <li><a href="#about">About Us</a></li>
                                    <li><a href="">Join Newsletter</a></li>

                                </ul>
                            </div>
                        </div>
                    </div>
                    <div id="about" class="col_1_of_footer span_1_of_footer">
                        <div class="sidebar-nav1">
                            <div class="footer-right">
                                <h4>Fathima Trade Centre</h4>
                                <ul>
                                    <li><a href="#">Head Office</a></li>
                                    <li><a href="#">Kandy</a></li>
                                    <li><a href="#">Gampola</a></li>
                                    <li><a href="#">Other</a></li>
                                    <li><a href="#">RSS</a></li>
                                    <li><a href="#">Twitter</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="clear"></div>
                </div>
                <div class="clear"></div>
            </div>
            <div class="copy">
                <p class="copy">© 2021 Designed by <a href="#" target="_blank">eSeller</a> </p>
            </div>
        </div>
    </div>
    <%--end footer--%>
</body>
</html>
