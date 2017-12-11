<!DOCTYPE html>
<html lang="en">
<head>
  
</head>
<body>
<h1>Login</h1>
<form action="{{'/users/login'}}}" method="post">
    <div class="form-group">
        <label for="text"> Enter your Name</label>
        <input type="text" class="form-control" id="name" placeholder="enter your name">


        <label for="text"> Enter your Password</label>
        <input type="password" class="form-control" id="password" placeholder="enter your password">
    </div>
    <button type="submit" class="btn btn-primary">Login</button>
    <input type="hidden" value="{}" name="_token">
</form>
</body>
</html>