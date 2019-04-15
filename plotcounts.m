function plotcounts()
    plot_counts_from_file('ball.txt');
    plot_counts_from_file('cube.txt');
end

function plot_counts_from_file(filename)
   figure();
   data = dlmread(filename);
   volumes = data(:, 1);
   counts = data(:, 2:end)';
   plot(counts);
   legend(cellfun(@num2str, mat2cell(volumes), 'un', 0));
   title(filename);
end