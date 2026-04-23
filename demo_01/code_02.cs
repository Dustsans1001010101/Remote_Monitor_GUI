 // CLIENT EVENTS
    private void SetupClientEvents()
    {
        _client.OnLog += msg => AppendClientLog(msg);

        _client.OnConnectionChanged += connected =>
        {
            Invoke((MethodInvoker)(() =>
            {
                button9.Enabled = !connected;
                button10.Enabled = connected;

                Host.Items.Clear();
                User.Items.Clear();
                Status.Items.Clear();

                if (connected)
                {
                    Host.Items.Add(Environment.MachineName);
                    User.Items.Add(Environment.UserName);
                    Status.Items.Add("Connected");

                    toolStripStatusLabel1.Text =
                        $"Connected → {textBox2.Text}:{numericUpDown2.Value}";
                }
                else
                {
                    Host.Items.Add("-");
                    User.Items.Add("-");
                    Status.Items.Add("Disconnected");

                    toolStripStatusLabel1.Text = "Disconnected";
                }
            }));
        };
    }
