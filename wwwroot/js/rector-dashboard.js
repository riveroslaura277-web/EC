/* ── rector-dashboard.js ── */

// Reloj en tiempo real
const DIAS = ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'];
const MESES = ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto',
    'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'];

function tick() {
    const n = new Date();
    const p = v => String(v).padStart(2, '0');
    document.getElementById('ct').textContent =
        `${p(n.getHours())}:${p(n.getMinutes())}:${p(n.getSeconds())}`;
    document.getElementById('cd').textContent =
        `${DIAS[n.getDay()]}, ${n.getDate()} de ${MESES[n.getMonth()]} de ${n.getFullYear()}`;
}
tick();
setInterval(tick, 1000);

// ── GRÁFICAS ──
let rendChart;
let currentMode = 'bar';

function initCharts(rendLabels, rendActual, rendAnterior, notasLabels, notasData) {

    // Rendimiento académico (barras por defecto)
    const ctxR = document.getElementById('cRend').getContext('2d');
    rendChart = buildRendChart(ctxR, 'bar', rendLabels, rendActual, rendAnterior);

    // Distribución de notas
    const ctxN = document.getElementById('cNotas').getContext('2d');
    new Chart(ctxN, {
        type: 'bar',
        data: {
            labels: notasLabels,
            datasets: [{
                label: 'Estudiantes',
                data: notasData,
                backgroundColor: [
                    'rgba(226,75,74,.7)',
                    'rgba(208,92,30,.7)',
                    'rgba(29,158,117,.75)',
                    'rgba(55,138,221,.75)',
                    'rgba(127,119,221,.75)'
                ],
                borderColor: ['#E24B4A', '#D85A30', '#1D9E75', '#378ADD', '#7F77DD'],
                borderWidth: 1.5,
                borderRadius: 4
            }]
        },
        options: chartOptions(false)
    });
}

function buildRendChart(ctx, type, labels, actual, anterior) {
    return new Chart(ctx, {
        type: type,
        data: {
            labels: labels,
            datasets: [
                {
                    label: 'Año actual',
                    data: actual,
                    backgroundColor: type === 'bar' ? 'rgba(29,158,117,.7)' : 'rgba(29,158,117,.15)',
                    borderColor: '#1D9E75',
                    borderWidth: 1.5,
                    borderRadius: type === 'bar' ? 4 : 0,
                    fill: type === 'line',
                    tension: .4,
                    pointBackgroundColor: '#1D9E75',
                    pointRadius: 3
                },
                {
                    label: 'Año anterior',
                    data: anterior,
                    backgroundColor: type === 'bar' ? 'rgba(55,138,221,.5)' : 'rgba(55,138,221,.1)',
                    borderColor: '#378ADD',
                    borderWidth: 1.5,
                    borderRadius: type === 'bar' ? 4 : 0,
                    fill: type === 'line',
                    tension: .4,
                    pointBackgroundColor: '#378ADD',
                    pointRadius: 3
                }
            ]
        },
        options: chartOptions(true)
    });
}

function toggleChart() {
    currentMode = currentMode === 'bar' ? 'line' : 'bar';
    const ctx = document.getElementById('cRend').getContext('2d');
    const labels = rendChart.data.labels;
    const actual = rendChart.data.datasets[0].data;
    const anterior = rendChart.data.datasets[1].data;
    rendChart.destroy();
    rendChart = buildRendChart(ctx, currentMode, labels, actual, anterior);
}

function chartOptions(hasLegend) {
    return {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
            legend: {
                display: hasLegend,
                labels: { color: '#718096', font: { size: 10 }, boxWidth: 12 }
            }
        },
        scales: {
            x: { ticks: { color: '#a0aec0', font: { size: 9 } }, grid: { color: '#edf2f7' } },
            y: { ticks: { color: '#a0aec0', font: { size: 9 } }, grid: { color: '#edf2f7' } }
        }
    };
}