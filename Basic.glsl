//version 330 inserted here by shader precompiler

#ifdef _VERTEX_
	uniform mat4 modelview_matrix;            
	uniform mat4 projection_matrix;
	
	in vec3  vertex_position;
	in vec2  vertex_uv;
	in vec3  vertex_normal;
	in float vertex_ao;
	in float square;
	
	out Vertex {
		vec3 normal;
		vec4 position;
		float ao;
	} Vert;
	
	void main(void)
	{
		Vert.normal = ( modelview_matrix * vec4( vertex_normal, 0 ) ).xyz;
		Vert.position = projection_matrix * modelview_matrix * vec4( vertex_position, 1 );
		Vert.ao = vertex_ao;
		gl_Position = Vert.position;
	}
#endif

#ifdef _FRAGMENT_
	precision highp float;
	
	const vec3 ambient = vec3( 0.1, 0.1, 0.1 );
	const vec3 lightVecNormalized = normalize( vec3( 0.5, 0.5, 2 ) );
	const vec3 lightColor = vec3( 0.7, 0.7, 0.7 );
	const vec3 lightColorRefl = vec3( 1.0, 0.0, 0.0 );
	
	in Vertex {
		vec3 normal;
		vec4 position;
		float ao;
	} Vert;
	
	out vec4 out_frag_color;
	
	void main(void)
	{
		float diffuse = clamp( dot( lightVecNormalized, normalize( Vert.normal ) ), 0.0, 1.0 );
		float diffuseRefl = clamp( dot( lightVecNormalized, normalize( -Vert.normal ) ), 0.0, 1.0 );
		out_frag_color = vec4( ambient + (diffuse * lightColor + diffuseRefl*lightColorRefl)*Vert.ao, 1.0 );
	}
#endif
