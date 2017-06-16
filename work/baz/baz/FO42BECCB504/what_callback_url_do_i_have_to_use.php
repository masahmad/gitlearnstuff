<html>
<head>
<title>Get callback URL for config</title>
</head>
<body>
<label for="select_provider">Select the provider:</label>
<select onchange="get_callback(this.value);" id="select_provider">
  <option value="facebook">Facebook</option>
  <option value="twitter">Twitter</option>
  <option value="google">Google</option>
</select>
<div id="callbackurl"></div>
<script>
function get_callback(provider){
var currenturl=window.location.href;
document.getElementById('callbackurl').innerText=currenturl.replace("what_callback_url_do_i_have_to_use.php","callback.php")+"?provider="+provider;
}
</script>
</body>
</html>