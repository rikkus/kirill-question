using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using KirillQuestion.Implementations;

namespace HS.Benchmark.Playground
{
    public partial class MainWindow : Form
    {
        private static readonly TimeSpan MaxTimePerTrial = TimeSpan.FromSeconds(5);
        private readonly HtmlResultsCollector summaryResultsCollector = new HtmlResultsCollector();
        private readonly ListViewResultsCollector intermediateResultsCollector;

        public MainWindow()
        {
            InitializeComponent();

            webBrowser.DocumentText = "<html><body><h1>Running benchmarks...</h1></body></html>";

            intermediateResultsCollector =  new ListViewResultsCollector(listView);

            var timer = new Timer();
            timer.Tick += TimerElapsed;
            timer.Interval = 500;
            timer.Start();
        }

        void TimerElapsed(object sender, EventArgs e)
        {
            ((Timer) sender).Stop();

            RunBenchmark();
        }

        private void RunBenchmark()
        {
            using (var benchmark = BackgroundBenchmark.Create(MaxTimePerTrial, FinishedAction))
            {
                var text = new StreamReader(
                    Assembly.GetExecutingAssembly().GetManifestResourceStream(@"HS.Benchmark.Playground.Input.txt")
                    ).ReadToEnd();

                AddBenchmark("Ddkk", () => new Dbkk().InsertSpaceBetweenCrLfs(text), benchmark);
                AddBenchmark("fholm", () => new Fholm().InsertSpaceBetweenCrLfs(text), benchmark);
                AddBenchmark("JaredParsons", () => new JaredParsons().InsertSpaceBetweenCrLfs(text), benchmark);
                AddBenchmark("JordanTerrell", () => new JordanTerrell().InsertSpaceBetweenCrLfs(text), benchmark);
                AddBenchmark("JordanTerrellCached", () => new JordanTerrellCached().InsertSpaceBetweenCrLfs(text), benchmark);
                AddBenchmark("KooKiz2", () => new KooKiz2().InsertSpaceBetweenCrLfs(text), benchmark);
                AddBenchmark("PiersH", () => new PiersH().InsertSpaceBetweenCrLfs(text), benchmark);
                AddBenchmark("PiersH2", () => new PiersH().InsertSpaceBetweenCrLfs(text), benchmark);
                AddBenchmark("Robert2", () => new Robert2().InsertSpaceBetweenCrLfs(text), benchmark);
                AddBenchmark("Warturtle", () => new Warturtle().InsertSpaceBetweenCrLfs(text), benchmark);

                benchmark.Begin();
            }
        }

        private void AddBenchmark(string name, BasicAction action, BackgroundBenchmark benchmark)
        {
            benchmark.Add
                (
                name,
                action,
                summaryResultsCollector.AddResult,
                intermediateResultsCollector.AddResult
                );
        }

        private void FinishedAction(InvocationResult result)
        {
            if (InvokeRequired)
                Invoke(new InvocationCompleteAction(FinishedAction), result);
            else
                webBrowser.DocumentText = summaryResultsCollector.Document.ToString();
        }
    }
}
