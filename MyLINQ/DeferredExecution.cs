using MyLINQ.Enums;

namespace MyLINQ
{
	internal class DeferredExecution
	{
		private List<SpanishVerbs> _verbsDict = [
			new SpanishVerbs("decir", "sagen", Ausxiliary.haber, true),
			new SpanishVerbs("aprender", "lernen", Ausxiliary.haber),
			new SpanishVerbs("llegar", "ankommen", Ausxiliary.haber),
			new SpanishVerbs("llevar", "mitbringen", Ausxiliary.haber),
			new SpanishVerbs("tomar", "nehmen", Ausxiliary.haber),
			new SpanishVerbs("dar algo a alguien", "jmdm. etw. geben", Ausxiliary.haber, true),
			new SpanishVerbs("saber", "wissen", Ausxiliary.haber, true),
			new SpanishVerbs("conocer", "kennenlernen", Ausxiliary.haber, true)
			];

		public DeferredExecution()
		{
			DeferredAppend();
		}

		/// <summary>
		/// .Append() always creates a new sequence what cause in performance implications, for adding multiple elements use .Concat()
		/// </summary>
		public void DeferredAppend()
		{
			// It doesn't care what kind of collection or sequence is used
			var irregular = _verbsDict.Where(x => x.Irregular);

			// Function return a new sequence doesn't modify the "irregular" collection
			_verbsDict.Append(new SpanishVerbs("entender", "verstehen", Ausxiliary.haber, true));
			// Modified the "irregular" sequence and return nothing
			_verbsDict.Add(new SpanishVerbs("encontrar", "finden", Ausxiliary.haber, true));	

			foreach (var verb in irregular)
			{
				Console.WriteLine($"Irregular verb DE: {verb.DE} --> {verb.ES}");
			}
		}
	}

	internal record SpanishVerbs(string ES, string DE, Ausxiliary Ausxiliary, bool Irregular = false);
}
