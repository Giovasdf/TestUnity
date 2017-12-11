<?php

/*
|--------------------------------------------------------------------------
| Application Routes
|--------------------------------------------------------------------------
|
| Here is where you can register all of the routes for an application.
| It is a breeze. Simply tell Lumen the URIs it should respond to
| and give it the Closure to call when that URI is requested.
|
*/

$router->group(['middleware'=>['auth']],function () use($router){
    $router->get('/users',['uses'=>'UsersController@index']);
    $router->get('/scores',['uses'=>'ScoresController@index']);
    $router->post('/scores',['uses'=>'ScoresController@createScore']);

    $router->get('/config',['uses'=>'ConfigController@index']);
    $router->post('/config',['uses'=>'ConfigController@createConfig']);
    $router->put('/config',['uses'=>'ConfigController@updateConfig']);
    $router->delete('/config',['uses'=>'ConfigController@deleteConfig']);



});

$router->post('/users',['uses'=>'UsersController@createUser']);

$router->post('/users/login',['uses'=>'UsersController@getToken']);

$router->get('/', function () use ($router) {
 //   return $router->app->version();
    return view('login');

});



$router->get('/key',function (){
    return str_random(32);
});

