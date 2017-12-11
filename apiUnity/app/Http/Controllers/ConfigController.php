<?php

namespace App\Http\Controllers;

use App\Config;

use Illuminate\Http\Request;

class ConfigController extends Controller
{
    function index(Request $request){
        if($request->isJson()) {

            $config = Config::all();
            return response()->json($config, 200);
        }
        return response()->json(['error'=>'Unauthorized'],401,[]);
    }

    function createConfig(Request $request){
        if($request->isJson()) {

            $data = $request->json()->all();

            $config = Config::create([
                'PlayerSpeed' => $data['PlayerSpeed'],
                'durationTime' => $data['durationTime'],
                'PtosPerItem' => $data['PtosPerItem']

            ]);
            return response()->json([], 201);
        }
        return response()->json(['error'=>'Unauthorized'],401,[]);
    }
    function updateConfig(Request $request){

        $findObject=Config::where('id','=',$request->input('id'))->first();

        if($findObject!=null){

            $findObject->PlayerSpeed=$request->input('PlayerSpeed');
            $findObject->durationTime=$request->input('durationTime' );
            $findObject->PtosPerItem=$request->input('PtosPerItem' );

            $findObject->save();

            return response()->json($findObject,200);

        }
        else{
            return response()->json(['error'=>'Unauthorized'],401,[]);

        }


        return response()->json(['error'=>'Unauthorizedd'],401,[]);
    }

    function deleteConfig(Request $request){

        $findObject=Config::where('id','=',$request->input('id'))->first();

        if($findObject!=null){

            $findObject->delete();

            return response()->json('correctamente eliminado',200);

        }
        else{
            return response()->json(['error'=>'Unauthorized'],401,[]);

        }

        return response()->json(['error'=>'Unauthorizedd'],401,[]);


    }
}
