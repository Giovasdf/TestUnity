<?php

namespace App\Http\Controllers;

use App\Score;
use Illuminate\Http\Request;

class ScoresController extends Controller
{
    function index(Request $request){
        if($request->isJson()) {

            $scores = Score::all();
            return response()->json($scores, 200);
        }
        return response()->json(['error'=>'Unauthorized'],401,[]);
    }
    function createScore(Request $request){
        if($request->isJson()) {

            $data = $request->json()->all();

            $score = Score::create([
                'userName' => $data['userName'],
                'valScore' => $data['valScore'],

            ]);
            return response()->json([], 201);
        }

        return response()->json(['error'=>'Unauthorized'],401,[]);
    }
}
