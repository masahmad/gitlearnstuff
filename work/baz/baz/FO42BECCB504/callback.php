<?php
//embed all social classes
require 'TwitterUser.class.php';
require 'FacebookUser.class.php';
require 'GoogleUser.class.php';
//set the config parameters
require 'config.php';

$url_of_callback=str_replace("login_form.php","callback.php","http://$_SERVER[HTTP_HOST]".strtok($_SERVER["REQUEST_URI"],'?'))."?provider=".$_GET['provider'];

if (!empty($_GET['provider'])){ //if the provider queryparameter not is empty...
switch ($_GET['provider']){ //check the provider to get profile
case "twitter":
$user=new TwitterUser($config['twitter']); //init new twitteruser object
$user->gettoken($_GET['oauth_token'], $_GET['oauth_verifier']); //get a oauth user token
$user->getprofile(); //and get the profile
break;
case "google":
$config['google']['redir_url']=$url_of_callback; //google needs to have the redir_url in his config
$user=new GoogleUser($config['google']); //init new google object
$user->gettokens($_GET['code']); //get oauth user tokens
$user->getprofile(); //and get the profile
break;
case "facebook":
$user=new FacebookUser($config['facebook']); //init new facebookuser object
$user->gettokens($_GET['code'], $url_of_callback); //get oauth user tokens
$user->getprofile(); //and get the profile
break;
default: //don't know the provider, exit!
die("This provider is unknown");
break;
}
}else{ //provider is empty, exit!
die("Sorry, something went wrong");
}
if (empty($user->profile)){ die ("Couldn't get ".$_GET['provider']." profile!"); } //couldn't get profile, exit!
//some variables you can use in your script
$unique_user_id=$user->id;
$profile=$user->profile; //profile with some generic info (username, fullname, profile picture)
?>
<html>
<head>
<title>Welcome, <?php echo $profile['first_name'] ?></title>
</head>
<body>
<img src='<?php echo $profile['profilepic'] ?>' style='max-width:150px; max-height:150px; float:left;' />
<h2><?php echo $profile['full_name'] ?></h2>
<p><table>
<tr><td>Unique id:</td><td><?php echo $unique_user_id ?></td></tr>
<tr><td>Nickname/username:</td><td><?php echo $profile['nickname'] ?></td></tr>
<tr><td>Emailaddress (not available when using Twitter):</td><td><?php echo $profile['email'] ?></td></tr>
</table><p>
</body>
</html>