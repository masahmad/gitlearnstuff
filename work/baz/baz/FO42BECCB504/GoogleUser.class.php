<?php
class GoogleUser{
private $googleproject=array(
					'client_id'=>'',
					'client_secret'=>'',
					'redir_url'=>''
					);
private $tokens=array();				 
public $id;
public $email;
public $nickname="";
public $fullname="";
public $name=array();
public $profile=array();
public function __construct($config){
$this->googleproject=$config;
}
public function curl_post($url, array $postdata){
//set POST variables

//url-ify the data for the POST
$fields_string="";
foreach($postdata as $key=>$value) { $fields_string .= $key.'='.urlencode($value).'&'; }
rtrim($fields_string, '&');

//open connection
$ch = curl_init();

//set the url, number of POST vars, POST data
curl_setopt($ch,CURLOPT_URL, $url);
curl_setopt($ch,CURLOPT_POST, count($postdata));
curl_setopt($ch,CURLOPT_POSTFIELDS, $fields_string);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
//execute post
$return= curl_exec($ch);
//close connection
curl_close($ch);
return $return;
}	
public function login($redirto=""){
$unique_state=session_id ();
if (!empty($redirto)) $this->googleproject['redir_url']=$redirto;
$url='https://accounts.google.com/o/oauth2/auth?'.
	  'scope=email ' .
      'https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fplus.login&' .
      'state='.$unique_state.'&' .
      'redirect_uri='.urlencode($this->googleproject['redir_url']).'&'.
      'response_type=code&'.
      'client_id='.urlencode($this->googleproject['client_id']).'&' .
      'access_type=offline';
header("Location: ".$url);
exit();
}
public function gettokens($code=""){
if (empty($code)){ $code=$_SESSION['oauth2']['code']; unset($_SESSION['oauth2']['code']); }
$url="https://accounts.google.com/o/oauth2/token";
$post=array (
			'code'=>$code,
			'redirect_uri'=>$this->googleproject['redir_url'],
			'client_id'=>$this->googleproject['client_id'],
			'client_secret'=>$this->googleproject['client_secret'],
			'grant_type'=>'authorization_code'
			);
$this->tokens=json_decode($this->curl_post($url, $post),true);

$id_token=explode('.',$this->tokens['id_token']);
$claims=json_decode(base64_decode($id_token[1]),true);
$this->id=$claims['sub'];
$this->email=$claims['email'];
return $this->tokens;
}
public function logout(){
$url="https://accounts.google.com/o/oauth2/revoke?token=".urlencode($this->tokens['access_token']);
$result=file_get_contents($url);
return ($result!=false);
}
public function getprofile(){
$url="https://www.googleapis.com/plus/v1/people/me?access_token=".$this->tokens['access_token'];
$result=@file_get_contents($url);
if ($result!=false){
$googleprofile=json_decode($result, true);
$this->nickname=$googleprofile['nickname'];
$this->fullname=$googleprofile['displayName'];
$this->name=array('first_name'=>$googleprofile['name']['givenName'], 'last_name'=>$googleprofile['name']['familyName']);
$this->profile=array(
				'id'=>$googleprofile['id'],
				'nickname'=>$googleprofile['nickname'],
				'first_name'=>$googleprofile['name']['givenName'],
				'last_name'=>$googleprofile['name']['familyName'],
				'full_name' => $googleprofile['displayName'],
				'email'=>$googleprofile['emails'][0]['value'],
				'gender'=>$googleprofile['gender'],
				'profilepic'=>$googleprofile['image']['url'],
				'coverimage'=>$googleprofile['cover']['coverPhoto']['url'],
				'village'=>$googleprofile['placesLived'][0]['value'],
				'tagline'=>$googleprofile['tagline']
			);
return $this->profile;
}else{
return false;
}
}

}
?>