 // CLIENT TAB
    private async void button9_Click(object sender, EventArgs e)
    {
        try
        {
            string ip = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("Nhập IP server!");
                return;
            }

            button9.Enabled = false;
            await _client.ConnectAsync(ip, (int)numericUpDown2.Value);
        }
        catch (Exception ex)
        {
            button9.Enabled = true;
            MessageBox.Show(ex.Message);
        }
    }

    private void button10_Click(object sender, EventArgs e)
    {
        _client.Disconnect();
    }

    private async void button11_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBox3.Text)) return;

        await _client.SendChatAsync(textBox3.Text);
        textBox3.Clear();
    }

    private void button12_Click(object sender, EventArgs e)
    {
        richTextBox2.Clear();
    }

    private void button13_Click(object sender, EventArgs e)
    {
        _client.Disconnect();
        _server.Stop();
        Application.Exit();
    }

    private void AppendClientLog(string msg)
    {
        if (InvokeRequired)
        {
            Invoke((MethodInvoker)(() => AppendClientLog(msg)));
            return;
        }

        richTextBox2.AppendText(
            $"[{DateTime.Now:HH:mm:ss}] {msg}{Environment.NewLine}");

        richTextBox2.ScrollToCaret();
    }
