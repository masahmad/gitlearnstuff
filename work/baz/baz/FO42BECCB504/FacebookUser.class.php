<?php
class FacebookUser{
private $facebookauth=array(
					'client_id'		=>	"",
					'client_secret'	=>	""
					);
public $returnurl="";
private $useraccesstoken;
private $serveraccesstoken;
public $fullname="";
public $id;
public $email;
public  $profile; 
public function __construct($config){
$this->facebookauth['client_id']=$config['client_id'];
$this->facebookauth['client_secret']=$config['client_secret'];
$this->returnurl=(!empty($config['redir_url'])) ? $config['redir_url'] : null;
}
public function curl_del($path)
{

    $url =$path;
    $ch = curl_init();
    curl_setopt($ch, CURLOPT_URL,$url);
    curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "DELETE");
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    $result = curl_exec($ch);
    $httpCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);
    curl_close($ch);

    return $result;
}
public function login($redirurl=""){
if (!empty($redirurl)){ $this->returnurl=$redirurl; }
$url="https://graph.facebook.com/oauth/authorize?" . 
	"client_id=".$this->facebookauth['client_id'].
	"&redirect_uri=".urlencode($this->returnurl).
	"&scope=email"; //authorize with oauth2

header("Location: ".$url); //redirect the user to oauth 2
exit();
}
public function getserveraccesstoken($granttype){
$this->serveraccesstoken=@file_get_contents("https://graph.facebook.com/oauth/access_token?client_id=".$this->facebookauth['client_id']."&client_secret=".$this->facebookauth['client_secret']."&grant_type=".$granttype); //get a server access token
return ($this->serveraccesstoken!=false);
}
public function gettokens($code="", $returnurl=""){
if (empty($code)){ $code=$_SESSION['oauth2']['code']; unset($_SESSION['oauth2']['code']); }
if (!empty($returnurl)){ $this->returnurl=$returnurl; }
$url="https://graph.facebook.com/oauth/access_token?code=".urlencode($code)."&client_id=".$this->facebookauth['client_id']."&client_secret=".$this->facebookauth['client_secret']."&redirect_uri=".urlencode($this->returnurl); //get a shortlife accesstoken
$output=@file_get_contents($url);
parse_str($output, $output); //parse the access_token out of it
if (!empty($output['access_token'])){
$url_longlife="https://graph.facebook.com/oauth/access_token?client_id=".$this->facebookauth['client_id']."&client_secret=".$this->facebookauth['client_secret']."&fb_exchange_token=".$output['access_token']."&grant_type=fb_exchange_token";
parse_str(@file_get_contents($url_longlife),$output2); //parse the longlife access_token out of it
$this->useraccesstoken=$output2['access_token'];
$this->id=json_decode(file_get_contents("https://graph.facebook.com/me?fields=id&access_token=".$this->useraccesstoken),true)['id'];
return $output2['access_token']; //return the longlife accesstoken
}else{
return false;
}
}
public function getprofile(){
$me=json_decode(file_get_contents("https://graph.facebook.com/me?access_token=".$this->useraccesstoken),true);
$profile=array(
			'id'			=>		$me['id'],
			'first_name'	=>		$me['first_name'],
			'last_name'		=>		$me['last_name'],
			'nickname'		=>		str_replace(' ', '',$me['first_name'].$me['last_name']),
			'full_name'		=>		$me['first_name']." ".$me['last_name'],
			'email'			=>		$me['email'],
			'gender'		=>		$me['gender'],
			'profilepic'	=>		"https://graph.facebook.com/".$me['id']."/picture?height=500"

			);
$this->fullname=$me['first_name']." ".$me['last_name'];
$this->profile=$profile;
$this->email=$me['email'];
return $profile;
}
public function logout(){
return ($this->curl_del('https://graph.facebook.com/'.$this->id.'/permissions?access_token='.$this->useraccesstoken)=="true");
}
}
?>