﻿using GDWeave.Godot.Variants;
using GDWeave.Godot;
using GDWeave.Modding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulayre.Lure.Patches
{
	public class MainMenuPatcher : IScriptMod
	{
		public bool ShouldRun(string path) => path == "res://Scenes/Menus/Main Menu/main_menu.gdc";

		// returns a list of tokens for the new script, with the input being the original script's tokens
		public IEnumerable<Token> Modify(string path, IEnumerable<Token> tokens)
		{
			// wait for any newline token after any extends token

			var versionwaiter = new MultiTokenWaiter([
				t => t.Type is TokenType.CfContinue,
				t => t.Type is TokenType.Newline,
			], allowPartialMatch: false);

			var datedwaiter = new MultiTokenWaiter([
				t => t.Type is TokenType.Comma,
				t => t is IdentifierToken{Name:"dated"},
			], allowPartialMatch: false);

			var selectedwaiter = new MultiTokenWaiter([
				t => t is ConstantToken{Value: StringVariant {Value: "%serv_options"}},
				t => t.Type is TokenType.Period,
				t => t is IdentifierToken{Name:"selected"},
			], allowPartialMatch: false);
			// loop through all tokens in the script
			foreach (var token in tokens)
			{
				if (versionwaiter.Check(token))
				{
					yield return token;


					//func _replace_lobby_map_name(id,lobby_name:String,version:String) -> String:
					yield return new IdentifierToken("lobby_name");
					yield return new Token(TokenType.OpAssign);
					yield return new IdentifierToken("get_node");
					yield return new Token(TokenType.ParenthesisOpen);
					yield return new ConstantToken(new StringVariant("/root/SulayreLure/Patches"));
					yield return new Token(TokenType.ParenthesisClose);
					yield return new Token(TokenType.Period);
					yield return new IdentifierToken("_replace_lobby_map_name");
					yield return new Token(TokenType.ParenthesisOpen);
					yield return new IdentifierToken("lobby");
					yield return new Token(TokenType.Comma);
					yield return new IdentifierToken("lobby_name");
					yield return new Token(TokenType.Comma);
					yield return new IdentifierToken("lobb_version");
					yield return new Token(TokenType.ParenthesisClose);
					yield return new Token(TokenType.Newline, 2);

					yield return new Token(TokenType.PrVar);
					yield return new IdentifierToken("lobb_lure");
					yield return new Token(TokenType.OpAssign);
					yield return new IdentifierToken("lobb_version");
					yield return new Token(TokenType.Period);
					yield return new IdentifierToken("ends_with");
					yield return new Token(TokenType.ParenthesisOpen);
					yield return new ConstantToken(new StringVariant(".lure"));
					yield return new Token(TokenType.ParenthesisClose);
					yield return new Token(TokenType.Newline, 2);


					yield return new Token(TokenType.BuiltInFunc, (uint?)BuiltinFunction.TextPrintSpaced);
					yield return new Token(TokenType.ParenthesisOpen);
					yield return new IdentifierToken("lobb_lure");
					yield return new Token(TokenType.Comma);
					yield return new IdentifierToken("lobb_version");
					yield return new Token(TokenType.ParenthesisClose);
					yield return new Token(TokenType.Newline, 2);

					//func _filter_lobby_map(id,version:String) -> String:
					yield return new IdentifierToken("lobb_version");
					yield return new Token(TokenType.OpAssign);
					yield return new IdentifierToken("get_node");
					yield return new Token(TokenType.ParenthesisOpen);
					yield return new ConstantToken(new StringVariant("/root/SulayreLure/Patches"));
					yield return new Token(TokenType.ParenthesisClose);
					yield return new Token(TokenType.Period);
					yield return new IdentifierToken("_filter_lobby_map");
					yield return new Token(TokenType.ParenthesisOpen);
					yield return new IdentifierToken("lobby");
					yield return new Token(TokenType.Comma);
					yield return new IdentifierToken("lobb_version");
					yield return new Token(TokenType.ParenthesisClose);
					yield return new Token(TokenType.Newline, 2);

					yield return new Token(TokenType.PrVar);
					yield return new IdentifierToken("lobby_map");
					yield return new Token(TokenType.OpAssign);
					yield return new IdentifierToken("Steam");
					yield return new Token(TokenType.Period);
					yield return new IdentifierToken("getLobbyData");
					yield return new Token(TokenType.ParenthesisOpen);
					yield return new IdentifierToken("lobby");
					yield return new Token(TokenType.Comma);
					yield return new ConstantToken(new StringVariant("lure_map_id"));
					yield return new Token(TokenType.ParenthesisClose);
					yield return new Token(TokenType.Newline, 2);

					yield return new Token(TokenType.PrVar);
					yield return new IdentifierToken("has_map");
					yield return new Token(TokenType.OpAssign);
					yield return new IdentifierToken("get_node");
					yield return new Token(TokenType.ParenthesisOpen);
					yield return new ConstantToken(new StringVariant("/root/SulayreLure/Util"));
					yield return new Token(TokenType.ParenthesisClose);
					yield return new Token(TokenType.Period);
					yield return new IdentifierToken("map_exists");
					yield return new Token(TokenType.ParenthesisOpen);
					yield return new IdentifierToken("lobby_map");
					yield return new Token(TokenType.ParenthesisClose);
					yield return new Token(TokenType.OpOr);
					yield return new IdentifierToken("lobby_map");
					yield return new Token(TokenType.OpEqual);
					yield return new ConstantToken(new StringVariant(""));

					yield return new Token(TokenType.Newline, 2);

					yield return new Token(TokenType.PrVar);
					yield return new IdentifierToken("lobby_filter");
					yield return new Token(TokenType.OpAssign);
					yield return new IdentifierToken("Steam");
					yield return new Token(TokenType.Period);
					yield return new IdentifierToken("getLobbyData");
					yield return new Token(TokenType.ParenthesisOpen);
					yield return new IdentifierToken("lobby");
					yield return new Token(TokenType.Comma);
					yield return new ConstantToken(new StringVariant("lurefilter"));
					yield return new Token(TokenType.ParenthesisClose);

					yield return new Token(TokenType.Newline, 2);

				}
				else if (datedwaiter.Check(token))
				{
					yield return token;
					yield return new Token(TokenType.Comma);
					yield return new IdentifierToken("has_map");
					yield return new Token(TokenType.Comma);
					yield return new IdentifierToken("getLobbyData");
					yield return new Token(TokenType.ParenthesisOpen);
					yield return new IdentifierToken("lobby");
					yield return new Token(TokenType.Comma);
					yield return new IdentifierToken("Network");
					yield return new Token(TokenType.Period);
					yield return new IdentifierToken("MAX_PLAYERS");
					yield return new Token(TokenType.OpAdd);
					yield return new IdentifierToken("int");
					yield return new Token(TokenType.ParenthesisOpen);
					yield return new ConstantToken(new StringVariant("lure_max_diff"));
					yield return new Token(TokenType.ParenthesisClose);
					yield return new Token(TokenType.ParenthesisClose);
					yield return new Token(TokenType.Comma);
					yield return new IdentifierToken("lobb_lure");
					yield return new Token(TokenType.Comma);
					yield return new IdentifierToken("lobby_filter");
					yield return new Token(TokenType.Newline, 2);
				}
				else
				{
					// return the original token
					yield return token;
				}
			}
		}
	}
}
