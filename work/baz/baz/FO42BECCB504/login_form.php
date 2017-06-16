<?php
//embed all social classes
require 'TwitterUser.class.php';
require 'FacebookUser.class.php';
require 'GoogleUser.class.php';
//set the config parameters
require 'config.php';
$url_of_callback=str_replace("login_form.php","callback.php","http://$_SERVER[HTTP_HOST]".strtok($_SERVER["REQUEST_URI"],'?'));

if (!empty($_GET['provider'])){ //if the provider queryparameter not is empty...
switch ($_GET['provider']){ //check the provider to login
case "twitter":
$user=new TwitterUser($config['twitter']);
$user->login($url_of_callback."?provider=".$_GET['provider']);
break;
case "google":
$user=new GoogleUser($config['google']);
$user->login($url_of_callback."?provider=".$_GET['provider']);
break;
case "facebook":
$user=new FacebookUser($config['facebook']);
$user->login($url_of_callback."?provider=".$_GET['provider']);
break;
default:
echo "This provider is unknown";
break;
}
}else{
echo <<<EOF
<a href="?provider=twitter"><img src="sign-in-with-twitter.png" /></a>
<a href="?provider=facebook"><img src="sign-in-with-facebook.png" /></a>
<a href="?provider=google"><img src="sign-in-with-google.png" /></a>
EOF;
}